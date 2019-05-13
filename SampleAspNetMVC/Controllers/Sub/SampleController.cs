using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAspNetCore.Models;

namespace SampleAspNetCore.Controllers.Sub
{
    /**
    子控制器，需要设定不同的路径
    */
    [Route("sub")]
    public class SampleController
    {
        [Route("hello")]
        public string hello(){
            return "sub sample hello";
        }
    }
}