using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GelecekBilimde.Backend.Swagger
{
    public class BackendOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!(context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor))
            {
                return;
            }

            var attribute = context.MethodInfo.GetCustomAttribute<SwaggerOperationAttribute>();
            var actionName = attribute?.OperationId ?? controllerActionDescriptor.ActionName.Replace("Async", string.Empty);

            operation.OperationId = $"{controllerActionDescriptor.ControllerName}_{actionName}";
        }
    }
}