using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GelecekBilimde.Backend.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AutoScanXmlComments(this SwaggerGenOptions options)
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var comments = Directory.GetFiles(basePath, "*.xml", SearchOption.TopDirectoryOnly);

            foreach (var comment in comments)
            {
                options.IncludeXmlComments(comment);
            }
        }
    }
}