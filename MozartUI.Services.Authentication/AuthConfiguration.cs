using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace MozartUI.Services.Authentication;

public static class AuthConfiguration
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration, bool addAuthorization = true)
    {
        var jwtConfigSection = configuration.GetSection(nameof(JwtConfig));
        var jwtConfig = jwtConfigSection.Get<JwtConfig>();
        //services.Configure<SchedulerOptions>(configuration.GetSection("JobScheduler"));
        services.Configure<JwtConfig>(jwtConfigSection);
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
                    // HTTP/2
                    string accessToken = string.Empty;
                    if (context.Request.Protocol == "HTTP/2")
                    {
                        var token = Convert.ToString(context.Request.Headers["access_token"]) ?? "";
                        accessToken = token;
                    }
                    else
                    {
                        var token = Convert.ToString(context.Request.Cookies["access_token"]) ?? "";
                        accessToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                    }

                    //if (!string.IsNullOrEmpty(accessToken) && (context.HttpContext.WebSockets.IsWebSocketRequest || context.Request.Headers["Accept"] == "text/event-stream"))
                    //{
                    //    context.Token = accessToken;
                    //}
                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        context.Token = accessToken;
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

        return services;
    }
}
