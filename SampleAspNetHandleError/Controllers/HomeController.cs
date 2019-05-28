using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace SampleAspNetHandleError.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页，用来查看服务器是否正常.
        /// </summary>
        /// <remarks>无其他作用!</remarks>
        [HttpGet("/")]
        public string index()
        {
            return "hello SampleAspNetHandleError";
        }

        /// <summary>
        /// 全局异常记录处理
        /// </summary>
        /// <returns></returns>
        [HttpGet("/error")]
        public string error(){
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = feature?.Error;
            /*
            if(exception is System.DivideByZeroException){      //判断异常类型
                Console.WriteLine("yes");
            }
             */
            Console.WriteLine("Error Info-----" + exception);
            return  exception.GetType().FullName + ": " + exception.Message + "\r\n" + exception.StackTrace;
        }
    }
}