namespace MozartUI.Services.Authentication;

public class JwtConfig
{
    ///<summary>
    /// rsa cetificate 
    ///</summary>
    //public string CertificateData { get; set; } //"***"
    //public string CertificatePassword { get; set; }//"***"

    /// <summary>
    /// Defines the SymmetricSecurityKey fo hmc-sha256
    /// </summary>
    public string? SigningKey { get; set; }

    public string? Issuer { get; set; }

    public string? Audience { get; set; }

    public TimeSpan AccessTokenExpiration { get; set; } //timespan format "1.00:00:00"

    public TimeSpan RefreshTokenExpiration { get; set; }

    public string? ClientCookieExpiration { get; set; }
}
