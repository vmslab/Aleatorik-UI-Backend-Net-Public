using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MozartUI.Services.Authentication;

public class JwtAuthManager : IJwtAuthManager
{
    public IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary => _usersRefreshTokens.ToImmutableDictionary();
    private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens;  // can store in a database or a distributed cache
    private readonly JwtConfig _jwtConfig;

    public JwtAuthManager(IOptions<JwtConfig> jwtConfig)
    {
        _jwtConfig = jwtConfig.Value;
        _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
    }

    public TimeSpan AccessTokenExpiration { get { return _jwtConfig.AccessTokenExpiration; } }

    public TimeSpan RefreshTokenExpiration { get { return _jwtConfig.RefreshTokenExpiration; } }

    public string ClientCookieExpiration { get { return _jwtConfig.ClientCookieExpiration; } }

    // optional: clean up expired refresh tokens
    public void RemoveExpiredRefreshTokens(DateTime now)
    {
        var expiredTokens = _usersRefreshTokens.Where(x => x.Value.ExpireAt < now).ToList();
        foreach (var expiredToken in expiredTokens)
        {
            _usersRefreshTokens.TryRemove(expiredToken.Key, out _);
        }
    }

    // can be more specific to ip, user agent, device name, etc.
    public void RemoveRefreshTokenByUserName(string userName)
    {
        var refreshTokens = _usersRefreshTokens.Where(x => x.Value.UserName == userName).ToList();
        foreach (var refreshToken in refreshTokens)
        {
            _usersRefreshTokens.TryRemove(refreshToken.Key, out _);
        }
    }

    public List<Claim> GenerateClaims(string userName, string role, DateTime now)
    {
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userName),
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Role, role),
            
                //new Claim(ClaimTypes.Name, userName),
                //new Claim(ClaimTypes.Country, RegionInfo.CurrentRegion.DisplayName),

                new Claim(JwtRegisteredClaimNames.NameId, userName),
                new Claim(JwtRegisteredClaimNames.Jti, JwtUtil.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat,
                        new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Exp,
                        new DateTimeOffset(now.Add(_jwtConfig.AccessTokenExpiration)).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };
        return claims;
    }

    public AuthenticationProperties GenerateAuthenticationProperties(DateTime now)
    {
        return new AuthenticationProperties
        {
            IsPersistent = true,
            IssuedUtc = new DateTimeOffset(now),
            ExpiresUtc = new DateTimeOffset(now.Add(_jwtConfig.AccessTokenExpiration)),
        };
    }

    public JwtAuthResult GenerateTokens(string userName, IReadOnlyCollection<Claim> claims, DateTime now, RefreshToken? refresh = null)
    {
        var accessToken = _jwtConfig.GenerateAccessToken(claims, now);

        RefreshToken refreshToken = refresh;
        if (refreshToken is null)
        {
            refreshToken = new RefreshToken
            {
                UserName = userName,
                TokenValue = GenerateRefreshTokenString(),
                ExpireAt = now.Add(_jwtConfig.RefreshTokenExpiration)
            };
            _usersRefreshTokens.AddOrUpdate(refreshToken.TokenValue, refreshToken, (_, _) => refreshToken);
        }

        #region AspNet Idenity
        //var id = new ClaimsIdentity("Identity.Application", // REVIEW: Used to match Application scheme
        //   ClaimTypes.Name,
        //   ClaimTypes.Role);


        //id.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
        //id.AddClaim(new Claim(ClaimTypes.Name, userName));
        #endregion

        return new JwtAuthResult
        {
            //Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Auth.JwtScheme)),
            Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ClientCookieExpiration = _jwtConfig.ClientCookieExpiration,
        };
    }

    public RefreshToken GetRefreshToken(string refreshToken)
    {
        if (!_usersRefreshTokens.TryGetValue(refreshToken, out var existingRefreshToken))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return existingRefreshToken;
    }

    public Task<(ClaimsPrincipal, JwtSecurityToken?)> DecodeJwtToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new SecurityTokenException("Invalid token");
        }

        try
        {

            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                _jwtConfig.GetJwtOptions(),
                out var validatedToken);

            var result = (principal, validatedToken as JwtSecurityToken);

            return Task.FromResult(result);
        }
        catch (ArgumentException)
        {
            throw new SecurityTokenException("Token validation failed");
        }
        catch (SecurityTokenExpiredException)
        {
            throw new SecurityTokenException("Token expired");
        }
        catch (SecurityTokenInvalidSignatureException)
        {
            throw new SecurityTokenException("Invalid signature");
        }
        catch (SecurityTokenInvalidIssuerException ex)
        {
            throw new SecurityTokenException($"Invalid issuer: {ex.InvalidIssuer}");
        }
        catch (SecurityTokenInvalidAudienceException ex)
        {
            throw new SecurityTokenException($"Invalid audience: {ex.InvalidAudience}");
        }

    }

    static RandomNumberGenerator? _randomNumberGenerator;
    private static string GenerateRefreshTokenString()
    {
        var randomNumber = new byte[32];
        if (_randomNumberGenerator == null)
            _randomNumberGenerator = RandomNumberGenerator.Create();
        _randomNumberGenerator.GetBytes(randomNumber.AsSpan());
        return Convert.ToBase64String(randomNumber);
    }

    public JwtAuthResult Refresh(string refreshToken, DateTime now)
    {
        throw new NotImplementedException();
    }
}
