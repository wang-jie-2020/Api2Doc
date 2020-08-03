using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using Api2Doc.Models;

namespace Api2Doc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        public TokenController()
        {
        }

        /// <summary>
        /// 创建App
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<SysKey> CreateApp(string password)
        {
            var sk = new SysKey();
            return sk;
        }

        /// <summary>
        /// 获取App列表
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页量</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<SysKey>> GetAppList(string password, int pageNumber = 1, int pageSize = 20)
        {
            var sk = new List<SysKey>();
            return Ok(sk);
        }

        /// <summary>
        /// 清空数据库和上传文件
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Reset(string password)
        {
            return Ok();
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="appId">分配的应用ID</param>
        /// <param name="appKey">分配的应用密钥</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetToken(string appId, string appKey)
        {
            return string.Empty;
        }
    }
}
