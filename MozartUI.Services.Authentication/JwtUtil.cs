using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace AleatorikUI.Services.Authentication;

static class JwtUtil
{
    internal static List<Claim> GenerateClaims(string userName, string role, DateTime now)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, userName),
            new Claim(ClaimTypes.NameIdentifier, userName),
            new Claim(ClaimTypes.Role, role),
            
            //new Claim(ClaimTypes.Name, userName),
            //new Claim(ClaimTypes.Country, RegionInfo.CurrentRegion.DisplayName),
            
            new Claim(JwtRegisteredClaimNames.Name, userName),
            new Claim(JwtRegisteredClaimNames.NameId, userName),
            new Claim(JwtRegisteredClaimNames.Jti, JtiGenerator()),
            new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        };

        //foreach (var role in roles)
        //{
        //    claims.Add(new Claim("roles", role));
        //}

        return claims;
    }

    internal static string GenerateAccessToken(this JwtConfig config, IReadOnlyCollection<Claim> claims, DateTime now)
    {
        var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(
            claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

        // Create the JWT and write it to a string
        var jwtToken = new JwtSecurityToken(
            issuer: config.GetIssuer(),
            audience: shouldAddAudienceClaim ? config.GetAudience() : string.Empty,
            claims: claims,
            notBefore: now,
            expires: now.Add(config.AccessTokenExpiration),
            signingCredentials: config.CreateSigningCredentials());

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return encodedJwt;
    }

    internal static TokenValidationParameters GetJwtOptions(this JwtConfig settings)
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = settings.GetIssuer(),

            ValidateIssuerSigningKey = true,
            RequireSignedTokens = true,
            IssuerSigningKey = settings.GetSecurityKey(),

            ValidAudience = settings.GetAudience(),
            ValidateAudience = true,

            ValidateLifetime = true,
            RequireExpirationTime = true,

            LifetimeValidator = (before, expires, token, parameters) => expires > SystemClock.UtcNow,

            ClockSkew = TimeSpan.FromMinutes(1)
        };
    }
    /// <summary>
    /// Gets the JtiGenerator "jti" (JWT ID) Claim (default ID is a GUID)
    /// </summary>
    internal static string JtiGenerator() => Guid.NewGuid().ToString();

    /// <summary>
    /// Gets or sets the SigningCredentials The signing key to use when generating tokens.
    /// </summary>
    public static SigningCredentials CreateSigningCredentials(this JwtConfig config)
    {
        var signingKey = config.GetSecurityKey();
        return new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
    }

    public static string GetAudience(this JwtConfig config)
        => config.Audience ?? Auth.Audience;

    public static string GetIssuer(this JwtConfig config)
        => config.Issuer ?? Auth.Issuer;

    public static SecurityKey GetSecurityKey(this JwtConfig config)
    {
        if (string.IsNullOrEmpty(config.SigningKey))
        {
            throw new Exception("Setting SigningKey is null or empty");
        }

        var key = Encoding.ASCII.GetBytes(config.SigningKey);
        //key = new HMACSHA256(key).Key;
        return new SymmetricSecurityKey(key);
    }
}
