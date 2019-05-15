using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleAspNetCoreAuth.Controllers
{
    //如果[Authorize]挂在类层次，你需要用[AllowAnonymous]来让不需要认证的的方法通过
    [Authorize]
    [Route("[controller]/[action]")]
    public class SampleController
    {
        
        [AllowAnonymous]
        public string hello()
        {
            return "sample hello";
        }

        
        public string authz()
        {
            return "sample authz";
        }
    }
}