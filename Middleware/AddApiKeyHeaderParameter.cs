using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

public class AddApiKeyHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Verifica se o método ou a classe tem o atributo ApiKeyAttribute
        var hasApiKeyAttribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiKeyAttribute>().Any() ||
                                 context.MethodInfo.GetCustomAttributes(true).OfType<ApiKeyAttribute>().Any();

        if (hasApiKeyAttribute)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            // Adiciona o parâmetro x-api-key ao Swagger
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-api-key",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}
