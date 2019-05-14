using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

/**
基本范例控制器
 */
namespace SampleAspNetCore.Controllers
{
    [Route("sample")]
    public class SampleController: Controller
    {
        [Route("hello")]
        public string hello(){
            return "sample hello";
        }

        
    }

    
}