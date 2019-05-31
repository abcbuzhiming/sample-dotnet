using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace SampleAspNetSwagger.Controllers
{
    [Route("[controller]/[action]")]
    public class SampleController : Controller
    {
        /// <summary>
        /// 范例 hello.
        /// </summary>
        [HttpGet]
        public string hello()
        {
            
            return "sample hello";
        }
    }
}