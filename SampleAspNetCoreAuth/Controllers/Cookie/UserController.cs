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
using SampleAspNetCoreAuth.Constant;


namespace SampleAspNetCoreAuth.Controllers.Cookie
{
    [Route("cookie/[controller]/[action]")]
    public class UserController:Controller
    {
        //中间件HttpContext获取
        private IHttpContextAccessor _accessor;
        public UserController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        //登录页
        public string login()
        {
            return "cookie login page";
        }

        //登录过程
        public async Task<string> doLogin(){
            
            //这里要进行数据库查找用户等操作
            string username = "admin";
            //claim，在asp.net core体系里称为声明
            //1.0版本
            var claimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);       //表示基于声明的身份,使用的身份验证类型是cookie
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, username));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Role,"admin"));     //角色
                       

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);   
            
            HttpContext httpContext = _accessor.HttpContext;
            await httpContext.SignInAsync(claimsPrincipal);     //登录
            
            

            return "cookie doLogin success";
        }

        //登出
        public async Task<string> doLogout()
        {
            HttpContext httpContext = _accessor.HttpContext;
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);      //登出
            return "cookie doLogout success";
        }

        //注解，判断是否登录过
        [Authorize]
        public string authz()
        {
            return "cookie user authz";
        }

        //基于角色的授权，注意，区分大小写
        [Authorize(Roles = "admin")]
        public string role()
        {
            return "cookie user admin";
        }

        //基于策略的授权，注意，必须注册策略本身，否则启动就报错
        [Authorize(Policy = Permissions.UserRead)]
        public string policy()
        {
            return "cookie user read by policy";
        }

        //获取用户基本信息（如果cookie过期，得到的就是null）
        public string getUserInfo(){
             HttpContext httpContext = _accessor.HttpContext;
             var username = httpContext.User.Identity.Name;
            return "cookie getUserInfo:" + username;
        }
    }
}