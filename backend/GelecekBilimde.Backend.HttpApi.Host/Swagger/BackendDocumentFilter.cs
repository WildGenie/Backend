using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GelecekBilimde.Backend.Swagger
{
    public class BackendDocumentFilter : IDocumentFilter
    {
        private readonly string _basePath;

        public BackendDocumentFilter(IConfiguration configuration)
        {
            _basePath = configuration["Swagger:BasePath"];
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers.Add(new OpenApiServer
            {
                Url = _basePath
            });

            var originalPaths = new Dictionary<string, OpenApiPathItem>(swaggerDoc.Paths);
            swaggerDoc.Paths.Clear();

            foreach (var apiDescription in context.ApiDescriptions.OrderBy(d => d.GroupName).Reverse())
            {
                string routeKey = "/" + apiDescription.RelativePath.TrimEnd('/');
                string newRouteKey = routeKey.Replace(_basePath, "").EnsureStartsWith('/');

                if (swaggerDoc.Paths.ContainsKey(newRouteKey))
                {
                    continue;
                }

                if (!apiDescription.TryGetMethodInfo(out var methodInfo))
                {
                    continue;
                }

                var declaringType = methodInfo.DeclaringType;
                if (declaringType == null)
                {
                    continue;
                }

                if (!declaringType.Assembly.FullName.Contains("GelecekBilimde"))
                {
                    continue;
                }

                swaggerDoc.Paths.Add(newRouteKey, originalPaths[routeKey]);
            }
        }
    }
}