using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

namespace SampleAspNetCoreAuth
{
    //项目的配置类，项目的主要配置信息都在这个类里，它被Program.cs载入
    //本配置类的作用是实现基于Cookie的认证
    // 参考: 
    //ASP.NET Core 认证与授权[2]:Cookie认证 https://www.cnblogs.com/RainingNight/p/cookie-authentication-in-asp-net-core.html
    //https://github.com/RainingNight/AspNetCoreSample/tree/master/src/Functional/Authentication/CookieSample
    public class StartupCookie
    {
        public StartupCookie(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                // 在这里可以根据需要添加一些Cookie认证相关的配置，在本次示例中使用默认值就可以了。
                options.Cookie.HttpOnly = true;         //cookie是否httpOnly
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);       //超时时间
                options.Cookie.Name = "NCOOKIE";        //cookie名称
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            //app.UseHttpsRedirection();      //强制https跳转
            //app.UseCookiePolicy();

            app.UseAuthentication();        //添加了身份验证中间件到请求管道
            app.UseMvc();
        }
    }
}