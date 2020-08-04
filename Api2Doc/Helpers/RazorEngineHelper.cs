using Microsoft.OpenApi.Models;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2Doc.Helpers
{
    public class RazorEngineHelper
    {
        public static string GeneratorOpenApiDoc(string templatePath, OpenApiDocument model)
        {
            var template = System.IO.File.ReadAllText(templatePath);
            var result = Engine.Razor.RunCompile(template, Guid.NewGuid().ToString(), typeof(OpenApiDocument), model, null);
            return result;
        }
    }
}
