using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2Doc.Models
{
    /// <summary>
    /// 查询Token参数
    /// </summary>
    public class QueryApp
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int pageNumber { get; set; } = 1;

        /// <summary>
        /// 页量
        /// </summary>
        public int pageSize { get; set; } = 20;
    }
}
