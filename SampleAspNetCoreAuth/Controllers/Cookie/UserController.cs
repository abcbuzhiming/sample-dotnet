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


namespace SampleAspNetCoreAuth.Controllers.Cookie
{
    [Route("cookie/[controller]/[action]")]
    public class UserController
    {
        
        public string login()
        {
            return "cookie login page";
        }

        public string doLogin(){

            //claim，在asp.net core体系里称为声明
            //1.0版本
            var claimIdentity = new ClaimsIdentity("Cookie");
            return "cookie doLogin";
        }

        public string doLogout()
        {

            return "cookie doLogout";
        }
    }
}