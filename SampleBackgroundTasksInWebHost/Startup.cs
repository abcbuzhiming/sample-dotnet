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
using SampleBackgroundTasksInWebHost.Services;

namespace SampleBackgroundTasksInWebHost
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

            #region snippet1
            //services.AddHostedService<TimedHostedService>();        //注册后台服务- 带有定时器的后台任务
            #endregion

            #region snippet2
            //services.AddHostedService<ConsumeScopedServiceHostedService>();
            //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();        //作用域模式，但是暂时不知道意义在哪里
            #endregion

            #region snippet3
            services.AddHostedService<QueuedHostedService>();       //基于队列的后台任务
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();         //单例模式
            #endregion
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();        //跳转https
            app.UseMvc();
        }
    }
}
