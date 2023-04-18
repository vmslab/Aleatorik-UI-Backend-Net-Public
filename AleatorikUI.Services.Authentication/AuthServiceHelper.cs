using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace AleatorikUI.Services.Authentication;

public class AuthServiceHelper
{
    private readonly ILogger _logger;
    //private readonly IUserManagerService _userManager;
    private readonly IJwtAuthManager _authManager;


    //public IUserManagerService UserManager => _userManager;

    public IJwtAuthManager AuthManager => _authManager;

    public ILogger Logger => _logger;

    public string ClientCookieExpiration { get { return _authManager.ClientCookieExpiration; } }

    /// <summary>
    /// Default constructor
    /// </summary>
    //public AuthServiceHelper(ILogger logger, IUserManagerService userManager, IJwtAuthManager authManager)
    //{
    //    _logger = logger;
    //    _userManager = userManager;
    //    _authManager = authManager;
    //}
    public AuthServiceHelper(ILogger<AuthServiceHelper> logger, IJwtAuthManager authManager)
    {
        _logger = logger;
        _authManager = authManager;
    }

    public async Task<JwtAuthResult> SignIn(string userId, string password, bool rememberMe, HttpContext httpContext, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug($"Received login request for {userId}");

        var claims = _authManager.GenerateClaims(userId, "User", SystemClock.UtcNow);
        //var claims = _authManager.GenerateClaims(userName, "Admin", SystemClock.UtcNow);

        var jwtResult = _authManager.GenerateTokens(userId, claims, SystemClock.UtcNow);

        if (httpContext is not null && jwtResult is not null)
        {
            //await httpContext?.SignInAsync(IdentityConstants.ApplicationScheme,
            //    jwtResult.Principal,
            //    new AuthenticationProperties());
            httpContext.Response.Cookies.Append("access_token", WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(jwtResult.AccessToken!)), new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Expires = SystemClock.UtcNow.Add(_authManager.AccessTokenExpiration),
            });
            httpContext.Response.Cookies.Append("user_identity", WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(userId)), new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Expires = SystemClock.UtcNow.Add(_authManager.AccessTokenExpiration),
            });
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, jwtResult.Principal!);
        }

        _logger.LogInformation($"Login request for {userId} was successful");

        return jwtResult!;
    }

    public async Task SignOut(HttpContext httpContext)
    {
        if (httpContext is null)
            return;

        var identity = httpContext.User.Identity;
        if (identity is null)
            return;

        // optionally "revoke" JWT token on the server side --> add the current token to a block-list
        // https://github.com/auth0/node-jsonwebtoken/issues/375

        _authManager.RemoveRefreshTokenByUserName(identity.Name!);

        //await httpContext?.SignOutAsync(IdentityConstants.ApplicationScheme);
        //await httpContext?.SignOutAsync(IdentityConstants.ExternalScheme);
        //await httpContext?.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);

        httpContext.Response.Cookies.Delete("access_token");
        httpContext.Response.Cookies.Delete("user_identity");

        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public JwtAuthResult Refresh(string refreshToken, HttpContext httpContext)
    {
        // var jwtResult = _authManager.Refresh(refreshToken, SystemClock.UtcNow);
        var token = _authManager.GetRefreshToken(refreshToken);

        //var userRole = await _userManager.GetUserRole(token.UserName).ConfigureAwait(false);
        var claims = _authManager.GenerateClaims(token.UserName!, "User", SystemClock.UtcNow);
        //var claims = _authManager.GenerateClaims(token.UserName, "Admin", SystemClock.UtcNow);
        var jwtResult = _authManager.GenerateTokens(token.UserName!, claims, SystemClock.UtcNow, token); // need to recover the original claims

        //await httpContext?.SignInAsync(IdentityConstants.ApplicationScheme,
        //    jwtResult.Principal,
        //    new AuthenticationProperties());
        httpContext.Response.Cookies.Append("access_token", WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(jwtResult.AccessToken!)), new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Expires = SystemClock.UtcNow.Add(_authManager.AccessTokenExpiration),
        });
        httpContext.Response.Cookies.Append("user_identity", WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token.UserName!)), new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Expires = SystemClock.UtcNow.Add(_authManager.AccessTokenExpiration),
        });
        _logger.LogInformation($"User [{token.UserName}] has refreshed JWT token.");

        return jwtResult;
    }

    public RefreshToken GetRefreshToken(string refreshToken)
    {
        return _authManager.GetRefreshToken(refreshToken);
    }
}
