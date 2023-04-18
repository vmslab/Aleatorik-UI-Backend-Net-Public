using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AleatorikUI.Services.Configuration;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        object value = services.AddVersionedApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; });

        var scopeFactory = services
            .BuildServiceProvider()
            .GetRequiredService<IServiceScopeFactory>();

        using var scope = scopeFactory.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var descriptionProvider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

        services.AddSwaggerGen(options =>
        {
            foreach (var description in descriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        });

        return services;
    }

        // Configure() 메서드에서 사용할 부분
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
                c.DocExpansion(DocExpansion.None); 
            });

        return app;
    }

    // 헬퍼 메서드
    static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = $"Aleatorik UI Service API {description.ApiVersion}",
            Version = description.ApiVersion.ToString(),
            Description = "Aleatorik UI Service API 문서",
            Contact = new OpenApiContact
            {
                Name = "Mozart Cloud",
                Email = string.Empty,
                Url = new Uri("https://my.mozart-cloud.com/")
            }
        };
        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }
        return info;
    }
}
