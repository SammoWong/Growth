using Growth.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Growth.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, SwaggerOptions swaggerOptions)
        {
            if (!swaggerOptions.Enabled)
                return services;

            if (string.IsNullOrEmpty(swaggerOptions.Url))
                throw new KnownException("Swagger节点Url不能为空");

            var version = swaggerOptions.Version;
            var title = swaggerOptions.Title;
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc($"v{version}", new Swashbuckle.AspNetCore.Swagger.Info() { Title = title, Version = $"{version}" });
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
                {
                    options.IncludeXmlComments(file);
                });

                //权限Token
                options.AddSecurityDefinition("oauth2", new ApiKeyScheme()
                {
                    Description = "请输入带有Bearer的Token",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "Bearer",
                        Enumerable.Empty<string>()
                    }
                });
            });
            return services;
        }

        public static void UseSwagger(this IApplicationBuilder app)
        {

        }
    }
}
