using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.Api
{
    public class SwaggerSchemaFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var keys = new System.Collections.Generic.List<string>();
            var identifier = "Model";
            foreach (var key in swaggerDoc.Components.Schemas.Keys)
            {
                if (!key.Contains(identifier))
                    keys.Add(key);
            }
            foreach (var key in keys)
            {
                swaggerDoc.Components.Schemas.Remove(key);
            }
        }
    }
}
