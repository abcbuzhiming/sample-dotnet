using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using SampleAspNetLTP.LTP;

namespace SampleAspNetLTP.Controllers
{
    [Route("[controller]/[action]")]
    public class SampleController: Controller
    {
        [HttpGet]
        public string hello()
        {

            return "sample hello";
        }

        /// <summary>
        /// 分词接口
        /// </summary>
        /// <remarks>输入源内容，输出分词结果</remarks>
        /// <param name="sourceContent">源内容</param>
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public string seq([Required][FromForm]string sourceContent)
        {
            string result = Segmentation.splite(sourceContent);
            return result;
        }
    }
}