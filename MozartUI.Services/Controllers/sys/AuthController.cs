using System.Text;
using System.Web;
using AleatorikUI.Services.Authentication;
using AleatorikUI.Services.DAO.sys;
using AleatorikUI.Services.DTO.sys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using AleatorikUI.Services.DTO;
using AleatorikUI.Services.DTO.sys;

namespace AleatorikUI.Services.Controllers.sys;

[Authorize]
[Route("auth/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<AuthController> _logger;
    private readonly AuthServiceHelper _helper;
    private readonly IUserDao _userDao;


    public AuthController(ILogger<AuthController> logger, IUserDao userDao, AuthServiceHelper helper, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _userDao = userDao;
        _helper = helper;
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpPost("/api/auth/Login")]
    public async Task<IActionResult> Login(AuthInfo request)
    {
        var httpContext = _httpContextAccessor?.HttpContext;

        var user = _userDao.Login(request);

        if (user == null)
        {
            _logger.LogWarning($"Login request for {request.Email} was not successful");

            return Unauthorized();
        }
        var jwtResult = await _helper.SignIn(request.Email, "", false, httpContext).ConfigureAwait(false);

        if (jwtResult is null) return Unauthorized();

        _logger.LogInformation($"User [{request.Email}] logged in the system.");

        var ret = await TokenToLoginResult(httpContext, jwtResult);

        return Ok(ret);
    }

    [AllowAnonymous]
    [HttpGet("/api/auth/Refresh")]
    public async Task<IActionResult> Refresh()
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        var ret = new AuthInfo();

        try
        {
            if (httpContext is null) return Unauthorized();
            var accessToken = httpContext.Request.Cookies["access_token"];

            var refreshSource = httpContext.Request.Cookies["refresh_token"];
            byte[] tokenData = Convert.FromBase64String(refreshSource);
            string decodedString = Encoding.UTF8.GetString(tokenData);
            var refreshToken = Uri.UnescapeDataString(decodedString);

            if (string.IsNullOrEmpty(accessToken))
            {
                if (string.IsNullOrEmpty(refreshToken)) return Unauthorized();

                var jwtResult = _helper.Refresh(refreshToken, httpContext);
                if (jwtResult is null) return Unauthorized();

                ret = await TokenToLoginResult(httpContext, jwtResult);
            }
            else
            {
                var refresh = _helper.GetRefreshToken(refreshToken);
                ret = await TokenToLoginResult(httpContext, refresh.UserName, accessToken, refreshToken, _helper.ClientCookieExpiration);
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
        var identity = httpContext?.User.Identity;

        if (identity is null || !identity.IsAuthenticated)
            return NoContent();

        await _helper.SignOut(httpContext);

        var userName = identity?.Name;
        _logger.LogInformation($"User [{userName}] logged out the system.");
        return Ok("Succeed");
    }

    private async Task<AuthInfo> TokenToLoginResult(HttpContext httpContext, JwtAuthResult jwtResult)
    {
        return await TokenToLoginResult(
            httpContext,
            jwtResult.RefreshToken.UserName,
            jwtResult.AccessToken,
            jwtResult.RefreshToken.TokenValue,
            jwtResult.ClientCookieExpiration
        );
    }

    private async Task<AuthInfo> TokenToLoginResult(HttpContext httpContext, string userId, string accessToken, string refreshToken, string cookieExpiration)
    {
        var ret = new AuthInfo();

        ret.Email = userId;
        ret.Name = _userDao.GetByEmail(new UserInfo { Email = userId })?.Name;
        ret.Role = "User";

        ret.RefreshToken = refreshToken;
        ret.Expiration = cookieExpiration;
        ret.Success = true;
        ret.Confirmed = true;

        return ret;
    }
}
