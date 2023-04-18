using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AleatorikUI.Services.Configuration
{
    /// <summary>
    /// Swagger + Api Vision 관리 기능 구현
    /// </summary>
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

            services.AddSwaggerGen(c =>
            {
                foreach (var description in descriptionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                    c.IncludeXmlComments(string.Format(@"{0}\SwaggerDoc.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                }
            });

            return services;
        }

        /// <summary>
        /// Swagger 설정, Configure() 메서드에서 사용할 부분
        /// </summary>
        /// <param name="app"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    c.DocExpansion(DocExpansion.None);
                }
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
}
