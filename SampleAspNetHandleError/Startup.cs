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

namespace SampleAspNetHandleError
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
            //注意：错误处理是中间件实现的，中间件的处理存在顺序，和添加顺序一致，为了兜住所有异常，全局异常处理必须第一个被添加在pipe中
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();      //输出错误页
                app.UseExceptionHandler("/Error");     //用户自定义错误处理url路径，它会直接输出，不会跳转
            }
            else
            {
                app.UseExceptionHandler("/Error");     //用户自定义错误处理url路径，它会直接输出，不会跳转
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages();       //使用HTTP错误代码页中间件(该选项检查状态代码介于400和599之间且没有正文的响应,给他们加上状态码内容，注意中间有顺序问题，不能加在ExceptionHandler前面)
            //app.UseHttpsRedirection();      //强制https跳转
            app.UseMvc();
        }
    }
}
