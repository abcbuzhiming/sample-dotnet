using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleAspNetCore {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {

                //app.UseDeveloperExceptionPage();      //开发错误跳转页

                app.UseExceptionHandler (errorApp => {
                    errorApp.Run (async context => {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync ("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync ("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature> ();

                        // Use exceptionHandlerPathFeature to process the exception (for example, 
                        // logging), but do NOT expose sensitive error information directly to 
                        // the client.

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException) {
                            await context.Response.WriteAsync ("File error thrown!<br><br>\r\n");
                        }

                        var error = exceptionHandlerPathFeature?.Error;
                        //Console.WriteLine ("error.Message:" + error?.Message);        //获取异常消息
                        //Console.WriteLine ("1111:"  + error?.StackTrace);       //获取堆栈
                        
                        await context.Response.WriteAsync ("error.Message:" + error?.Message);
                        await context.Response.WriteAsync ("</body></html>\r\n");
                        await context.Response.WriteAsync (new string (' ', 512)); // IE padding
                    });
                });

            } else {
                //app.UseExceptionHandler("/Home/Error");     //错误处理跳转页
                app.UseExceptionHandler (errorApp => {
                    errorApp.Run (async context => {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync ("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync ("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature> ();

                        // Use exceptionHandlerPathFeature to process the exception (for example, 
                        // logging), but do NOT expose sensitive error information directly to 
                        // the client.

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException) {
                            await context.Response.WriteAsync ("File error thrown!<br><br>\r\n");
                        }

                        var error = exceptionHandlerPathFeature?.Error;
                        //Console.WriteLine ("error.Message:" + error?.Message);        //获取异常消息
                        //Console.WriteLine ("1111:"  + error?.StackTrace);       //获取堆栈
                        
                        await context.Response.WriteAsync ("error.Message:" + error?.Message);
                        await context.Response.WriteAsync ("</body></html>\r\n");
                        await context.Response.WriteAsync (new string (' ', 512)); // IE padding
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            //app.UseHttpsRedirection();      //强制https跳转
            app.UseStaticFiles ();
            app.UseCookiePolicy ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); //默认页处理器
            });
        }
    }
}