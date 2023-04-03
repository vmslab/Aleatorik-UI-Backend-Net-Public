using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MozartUI.Services.Authentication;

static class Auth
{
    /// <summary>
    /// The audience
    /// </summary>
    public const string Audience = "vms-solutions.com";//"vms.auth0.audience"

    /// <summary>
    /// The issuer
    /// </summary>
    public const string Issuer = "vms-solutions.com"; //"vms.auth0.issuer"


    public const string BasicScheme = "Basic";

    public const string JwtScheme = "Bearer"; // Schme = Bearer, BearerFormat = JWT

}
