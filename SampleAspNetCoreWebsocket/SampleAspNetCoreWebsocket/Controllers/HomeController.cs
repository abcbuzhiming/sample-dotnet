using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleAspNetCoreWebsocket.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("/")]
        public string index() 
        {
            return "hello SampleAspNetCoreWebSocket";
        }
    }
}
