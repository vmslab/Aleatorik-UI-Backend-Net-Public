using System.Text;
using AleatorikUI.Services.Authentication;
using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[Authorize]
[ApiVersion("1.0")]
[Route("auth/[controller]")]
[ApiController]
public class SamAuthController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<SamAuthController> _logger;
    private readonly AuthServiceHelper _helper;
    private readonly ISamUserDao _userDao;


    public SamAuthController(ILogger<SamAuthController> logger, ISamUserDao userDao, AuthServiceHelper helper, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _userDao = userDao;
        _helper = helper;
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpPost("/api/auth/Login")]
    public async Task<IActionResult> Login(SamAuthInfo request)
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        if (httpContext is null)
            return BadRequest();
        if (string.IsNullOrEmpty(request.Email))
            return BadRequest();

        var user = _userDao.Login(request);

        if (user == null)
        {
            _logger.LogWarning($"Login request for {request.Email} was not successful");

            return Unauthorized();
        }
        var jwtResult = await _helper.SignIn(request.Email, "", false, httpContext).ConfigureAwait(false);

        if (jwtResult is null) return Unauthorized();

        _logger.LogInformation($"User [{request.Email}] logged in the system.");

        var ret = TokenToLoginResult(httpContext, jwtResult);

        return Ok(ret);
    }

    [AllowAnonymous]
    [HttpGet("/api/auth/Refresh")]
    public async Task<IActionResult> Refresh()
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        if (httpContext is null) return BadRequest();

        var ret = new SamAuthInfo();

        try
        {
            var accessToken = httpContext.Request.Cookies["access_token"];

            var refreshSource = httpContext.Request.Cookies["refresh_token"] ?? string.Empty;
            byte[] tokenData = Convert.FromBase64String(refreshSource);
            string decodedString = Encoding.UTF8.GetString(tokenData);
            var refreshToken = Uri.UnescapeDataString(decodedString);

            if (string.IsNullOrEmpty(accessToken))
            {
                if (string.IsNullOrEmpty(refreshToken)) return Unauthorized();

                var jwtResult = _helper.Refresh(refreshToken, httpContext);
                if (jwtResult is null) return Unauthorized();

                ret = TokenToLoginResult(httpContext, jwtResult);
            }
            else
            {
                var refresh = _helper.GetRefreshToken(refreshToken);
                if (string.IsNullOrEmpty(refresh.UserName)) return BadRequest();
                ret = TokenToLoginResult(httpContext, refresh.UserName, accessToken, refreshToken, _helper.ClientCookieExpiration);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await _helper.SignOut(httpContext);
        }

        return Ok(ret);
    }

    [HttpGet("/api/auth/Logout")]
    public async Task<IActionResult> Logout()
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        if (httpContext is null) return BadRequest();

        var identity = httpContext.User.Identity;

        if (identity is null || !identity.IsAuthenticated)
            return NoContent();

        await _helper.SignOut(httpContext);

        var userName = identity?.Name;
        _logger.LogInformation($"User [{userName}] logged out the system.");
        return Ok("Succeed");
    }

    private SamAuthInfo TokenToLoginResult(HttpContext httpContext, JwtAuthResult jwtResult)
    {
        return TokenToLoginResult(
            httpContext,
            jwtResult.RefreshToken?.UserName ?? string.Empty,
            jwtResult.AccessToken ?? string.Empty,
            jwtResult.RefreshToken?.TokenValue ?? string.Empty,
            jwtResult.ClientCookieExpiration ?? string.Empty
        );
    }

    private SamAuthInfo TokenToLoginResult(HttpContext httpContext, string userId, string accessToken, string refreshToken, string cookieExpiration)
    {
        var ret = new SamAuthInfo();

        ret.Email = userId;
        ret.Name = _userDao.GetByEmail(new SamUserInfo { Email = userId })?.Name;
        ret.Role = "User";

        ret.RefreshToken = refreshToken;
        ret.Expiration = cookieExpiration;
        ret.Success = true;
        ret.Confirmed = true;

        return ret;
    }
}
