using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleAspNetCoreAuth.Controllers
{
    [Route("[controller]")]
    public class SampleController
    {
        [Route("[action]")]
        public string hello()
        {
            return "sample hello";
        }

        [Authorize]
        [Route("[action]")]
        public string authz()
        {
            return "sample authz";
        }
    }
}