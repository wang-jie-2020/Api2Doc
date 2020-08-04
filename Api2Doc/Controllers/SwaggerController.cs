using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using Api2Doc.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using System.Net.Http;

namespace Api2Doc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SwaggerController : ControllerBase
    {
        private readonly SwaggerGenerator _swaggerGenerator;
        private readonly IWebHostEnvironment _environment;

        public SwaggerController(SwaggerGenerator swaggerGenerator, IWebHostEnvironment environment)
        {
            _swaggerGenerator = swaggerGenerator;
            _environment = environment;
        }

        /// <summary>
        /// 从swagger中直接拿openApi文档
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDocFromSwaggerInner(string version = "v1")
        {
            //Condition：SwaggerGenerator注册
            var json = _swaggerGenerator.GetSwagger(version);
            if (json == null)
            {
                throw new Exception("Swagger Json cannot be equal to null！");
            }

            //核心思路还是从html转其他格式的文档，但还未找到合适的组件
            var provider = new FileExtensionContentTypeProvider();
            var mime = provider.Mappings[".html"];

            var html = Api2Doc.Helpers.RazorEngineHelper.GeneratorOpenApiDoc($"{_environment.WebRootPath}\\swagger2Doc.cshtml", json);
            var bytes = System.Text.Encoding.UTF8.GetBytes(html);

            return File(bytes, mime);
            //return Ok(JsonConvert.SerializeObject(json));
        }

        /// <summary>
        /// 通过swagger的Url拿openApi文档
        /// 结论：1.从url访问拿到的api文档不是严格的openApi文档，很像但不是
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDocBySwaggerUrl(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync(url);
                var result = await message.Content.ReadAsStringAsync();   //System.IO.File.ReadAllText(@"D:\Code\Api2Doc\Api2Doc\swagger.json");

                var json = JsonConvert.DeserializeObject<OpenApiDocument>(result, new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        args.ErrorContext.Handled = true;
                    }
                });

                return Ok(JsonConvert.SerializeObject(json));
            }
        }
    }
}