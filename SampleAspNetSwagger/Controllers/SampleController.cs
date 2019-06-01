using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;


namespace SampleAspNetSwagger.Controllers
{
    [Route("[controller]/[action]")]
    public class SampleController : Controller
    {
        /// <summary>
        /// 范例 hello.
        /// </summary>
        /// <remarks>用户登录接口</remarks>
        [HttpGet]
        public string hello()
        {

            return "sample hello";
        }

        /// <summary>
        /// 以queryString的方式传参
        /// </summary>
        /// <remarks>演示参数附加在url上提交</remarks>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        [HttpGet]
        public string query([Required]string name, [Required]string password)
        {
            Console.WriteLine("param:" + name + "|" + password);
            return "sample request by query param ";
        }

        /// <summary>
        /// 以form表单方式传参
        /// </summary>
        /// <remarks>演示参数以form表单的方式提交，参数名称必须加[FromForm]特性，另外可以用Consumes设定Content-Type头强制Swagger的请求头</remarks>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public string form([Required][FromForm]string name, [Required][FromForm]string password)
        {
            Console.WriteLine("param:" + name + "|" + password);
            return "sample request by form param ";
        }
    }
}