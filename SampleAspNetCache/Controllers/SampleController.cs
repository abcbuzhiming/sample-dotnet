using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleAspNetCache.Controllers
{
    [Route("[controller]/[action]")]
    public class SampleController : Controller
    {
        /// <summary>
        /// 范例 hello.
        /// </summary>
        
        public string hello()
        {
            
            return "sample hello";
        }
    }
}