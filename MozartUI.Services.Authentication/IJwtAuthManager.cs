using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace MozartUI.Services.Authentication;

public interface IJwtAuthManager
{
    TimeSpan AccessTokenExpiration { get; }
    TimeSpan RefreshTokenExpiration { get; }
    string ClientCookieExpiration { get; }
    IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
    List<Claim> GenerateClaims(string userName, string role, DateTime now);
    AuthenticationProperties GenerateAuthenticationProperties(DateTime now);
    JwtAuthResult GenerateTokens(string userName, IReadOnlyCollection<Claim> claims, DateTime now, RefreshToken refresh = null);
    // JwtAuthResult Refresh(string refreshToken, DateTime now);
    RefreshToken GetRefreshToken(string refreshToken);
    Task<(ClaimsPrincipal, JwtSecurityToken?)> DecodeJwtToken(string token);

    void RemoveExpiredRefreshTokens(DateTime now);
    void RemoveRefreshTokenByUserName(string userName);
}

public class JwtAuthResult
{
    public ClaimsPrincipal? Principal { get; set; }

    public string? AccessToken { get; set; }

    public RefreshToken? RefreshToken { get; set; }

    public string? ClientCookieExpiration { get; set; }
}

public class RefreshToken
{
    public string? UserName { get; set; }    // can be used for usage tracking
                                             // can optionally include other metadata, such as user agent, ip address, device name, and so on

    public string? TokenValue { get; set; }

    public DateTime ExpireAt { get; set; }
}
