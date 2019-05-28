using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Sinks;


namespace SampleAspNetSerilog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Serilog日志配置
            Log.Logger = new LoggerConfiguration()
            //.Enrich.WithCaller()
            .MinimumLevel.Debug()       //最小的输出单位是Debug级别的
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)      //将Microsoft前缀的日志的最小输出级别改成Information
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Level:u3} {Message:lj}{NewLine}{Exception}")       //输出到控制台，并定义模板
            //.WriteTo.File(@"default-.log", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information,outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")      //写入文件日志，级别INF，每天一个
            .WriteTo.File(Configuration["Logging:LogFile"], rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information,outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")      //写入文件日志，级别INF，每天一个
            .CreateLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePages();
            //app.UseHttpsRedirection();        //强制https跳转
            app.UseMvc();
        }
    }
}
