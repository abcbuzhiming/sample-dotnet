using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SampleAspNetCoreAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();     //Base
            //WebHost.CreateDefaultBuilder(args).UseStartup<StartupCookie>();       //基于cookie的认证配置
            WebHost.CreateDefaultBuilder(args).UseStartup<StartupJwt>();        //基于JWT on Http Header的认证配置
    }
}
