using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SampleAspNetCoreAuth.Models;
using Microsoft.Extensions.Logging;

namespace SampleAspNetCoreAuth.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;


        public UserController(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }
        //登入页面
        public string login()
        {

            return "login page";
        }

        //登入处理
        public string doLogin()
        {

            return "doLogin";
        }


        //登出
        public string doLogout()
        {

            return "doLogout";
        }

        //拒绝访问的跳转url
        public string accessDeny()
        {
            return "access Deny";
        }
    }
}