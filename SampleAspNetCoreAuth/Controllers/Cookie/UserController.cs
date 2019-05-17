using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SampleAspNetCoreAuth.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SampleAspNetCoreAuth.Controllers.Cookie
{
    [Route("cookie/[controller]/[action]")]
    public class UserController:Controller
    {
        private IHttpContextAccessor _accessor;
        public UserController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string login()
        {
            return "cookie login page";
        }

        public async Task<string> doLogin(){

            string username = "admin";
            //claim，在asp.net core体系里称为声明
            //1.0版本
            var claimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);       //表示基于声明的身份,使用的身份验证类型是cookie
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, username));
            

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);   
            
            HttpContext httpContext = _accessor.HttpContext;
            await httpContext.SignInAsync(claimsPrincipal);     //登录
            
            

            return "cookie doLogin success";
        }

        public async Task<string> doLogout()
        {
            HttpContext httpContext = _accessor.HttpContext;
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);      //登出
            return "cookie doLogout success";
        }

        [Authorize]
        public string authz()
        {
            return "cookie user authz";
        }
    }
}