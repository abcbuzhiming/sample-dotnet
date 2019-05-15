using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
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
    //本配置类的作用是实现基于Identity的基本认证和授权，为了简化，没有引入数据库部分
    //参考  https://docs.microsoft.com/zh-cn/aspnet/core/security/authentication/identity
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
           
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //向应用程序添加一组通用身份服务，包括默认UI，令牌提供程序，以及配置身份验证以使用身份Cookie
            services.AddDefaultIdentity<IdentityUser>();
            
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;           //密码必须包含数字    
                //options.Password.RequireLowercase = true;       //密码必须包含小写字母
                //options.Password.RequireUppercase= true;       //密码必须包含大写字母
                //options.Password.RequireNonAlphanumeric = true;     //密码必须包含非字母数字字符
                options.Password.RequiredLength = 6;        //密码长度
                options.Password.RequiredUniqueChars = 1;       //密码必须包含的最小唯一字符数

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);       //锁定时间，默认5分钟
                options.Lockout.MaxFailedAccessAttempts = 5;            //在锁定用户之前允许的失败访问尝试次数,默认为5
                options.Lockout.AllowedForNewUsers = true;              //指示是否可以锁定新用户。 默认为true

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";     //允许在密码中使用的字符数
                options.User.RequireUniqueEmail = false;        //指示应用程序是否需要为其用户提供唯一的电子邮件。 默认为false
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;         //cookie是否httpOnly
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);       //超时时间

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
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
            app.UseCookiePolicy();

            app.UseAuthentication();        //添加了身份验证中间件到请求管道
            app.UseMvc();
        }
    }
}
