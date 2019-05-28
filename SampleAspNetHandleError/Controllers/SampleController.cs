using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace SampleAspNetHandleError.Controllers
{
    [Route("[controller]/[action]")]
    public class SampleController : Controller
    {
        /// <summary>
        /// 用于产生错误的方法
        /// </summary>
        /// <returns></returns>
        public string except()
        {
            var a = 1;
            var b = 0;
            var c = a / b;
            return "sample except" + c;
        }
    }
}