using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace SampleAspNetSerilog.Controllers
{
    [Route("[controller]/[action]")]
    public class SampleController: Controller
    {
        /// <summary>
        /// 范例-输出日志
        /// </summary>
        [HttpGet]
        public string hello()
        {
            Log.Logger.Debug(this.GetType().FullName +":Debug级别测试");        //这个日志不会写入文件
            Log.Logger.Information(this.GetType().FullName +":Info级别测试");
            Log.Logger.Error(this.GetType().FullName +":Error级别测试");
            return "sample hello";
        }
    }
}