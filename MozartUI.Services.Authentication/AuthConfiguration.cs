using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using System.Security.Claims;
using System.Text;

namespace AleatorikUI.Services.Authentication;

public static class AuthConfiguration
{
    private static bool enableAccessLog = false;

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration, bool addAuthorization = true)
    {
        var jwtConfigSection = configuration.GetSection(nameof(JwtConfig));
        var jwtConfig = jwtConfigSection.Get<JwtConfig>();
        //services.Configure<SchedulerOptions>(configuration.GetSection("JobScheduler"));
        services.Configure<JwtConfig>(jwtConfigSection);

        bool.TryParse(configuration["AccessLog:Enable"], out enableAccessLog);

        //services.AddSingleton<IJwtAuthManager>();
        //services.AddScoped<IAsyncAuthorizationFilter, AuthorizationFilter>();
        //services.AddScoped<IAuthenticationHandler, JwtTokenAuthenticationHandler>();

        if (addAuthorization)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.NameIdentifier);
                });
            });
        }

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddCookie(option =>
        {
            option.ExpireTimeSpan = jwtConfig.AccessTokenExpiration;
        })
        //.AddScheme<AuthenticationSchemeOptions, JwtTokenAuthenticationHandler>(JwtTokenAuthenticationHandler.AuthenticationScheme, _ => { })
        .AddJwtBearer(options =>
        {
            //options.RequireHttpsMetadata = false;//=default
            //options.SaveToken = true; //=default

            // Sample
            //options.Authority = $"https://{config.GetAuthDomain()}/";
            //options.Audience = config.GetAudience();

            options.TokenValidationParameters = jwtConfig.GetJwtOptions();

            // Sample 
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    //var endpoint = context.HttpContext.Features.Get<IEndpointFeature>()?.Endpoint;
                    // HTTP/1.1
                    string accessToken = string.Empty;
                    var token = Convert.ToString(context.Request.Cookies["access_token"]) ?? "";

                    //if (!string.IsNullOrEmpty(accessToken) && (context.HttpContext.WebSockets.IsWebSocketRequest || context.Request.Headers["Accept"] == "text/event-stream"))
                    //{
                    //    context.Token = accessToken;
                    //}
                    if (!string.IsNullOrEmpty(token))
                    {
                        accessToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

                        context.Token = accessToken;
                    }
                    else
                    {
                        if (context.Request.Path.Value?.ToLower() != "/api/auth/login")
                        {
                            foreach (var c in context.Request.Cookies)
                            {
                                if (c.Key == "refresh_token")
                                {
                                    try
                                    {
                                        byte[] data = Convert.FromBase64String(c.Value);
                                        string decodedString = Encoding.UTF8.GetString(data);
                                        var refreshToken = Uri.UnescapeDataString(decodedString);

                                        if (!string.IsNullOrEmpty(refreshToken))
                                        {
                                            var authHelper = context.HttpContext.RequestServices.GetServices(typeof(AuthServiceHelper))?.FirstOrDefault();
                                            //var authManager = authManagers.Where(x => ((AuthServiceHelper)x).Count > 0).FirstOrDefault() as IJwtAuthManager;

                                            if (authHelper != null)
                                            {
                                                var authService = (AuthServiceHelper)authHelper;
                                                var jwtResult = authService.Refresh(refreshToken, context.HttpContext);

                                                context.Token = jwtResult.AccessToken;
                                            }
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }

                    if (enableAccessLog)
                    {
                        var identity = Convert.ToString(context.HttpContext.Request.Cookies["user_identity"]) ?? "";
                        var userName = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(identity));

                        var accesLog = new LogTemplate { User = userName, Path = context.Request.Path.Value, Message = "Access" };
                        Log.Information("User Access {@LogTemplate}", accesLog);
                    }

                    return Task.CompletedTask;
                },

                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Access-Control-Expose-Headers", "Token-Expired");
                        context.Response.Headers.Add("Token-Expired", "true");
                    }

                    return Task.CompletedTask;
                }
            };
        });

        services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
        services.AddSingleton<AuthServiceHelper>();

        return services;
    }
}
