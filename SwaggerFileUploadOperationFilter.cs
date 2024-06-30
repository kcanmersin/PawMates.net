using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PawMates.net
{
  
public class SwaggerFileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            return;

        foreach (var parameter in operation.Parameters)
        {
            var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
            var routeInfo = description.RouteInfo;

            if (parameter.Description == "File to upload")
            {
                operation.Parameters.Remove(parameter);
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties = {
                                    ["file"] = new OpenApiSchema
                                    {
                                        Description = "Upload File",
                                        Type = "file",
                                        Format = "binary"
                                    }
                                }
                            }
                        }
                    }
                };
                break;
            }
        }
    }
}

}