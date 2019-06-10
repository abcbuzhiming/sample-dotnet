using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SampleAspNetCoreAuth.Data;
using Microsoft.AspNetCore.Authorization;
using SampleAspNetCoreAuth.Constant;
using SampleAspNetCoreAuth.Authorization;


namespace SampleAspNetCoreAuth.Controllers.Jwt
{
    [Route("jwt/[controller]/[action]")]
    public class UserController:Controller
    {
        
        //登录页
        public string login()
        {
            return "jwt login page";
        }

        //登录过程
        public IActionResult  doLogin(){
            
            //这里要进行数据库查找用户等操作
            //var user = _store.FindUser(userDto.UserName, userDto.Password);
            //if (user == null) return Unauthorized();
            //如果通过，则开始生成token并发回
            
            int id = 1;
            string username = "admin";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.Secret);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,"api"),
                    new Claim(JwtClaimTypes.Issuer,"http://localhost:5200"),
                    new Claim(JwtClaimTypes.Id, id.ToString()),
                    new Claim(JwtClaimTypes.Name, username),
                    new Claim(JwtClaimTypes.Role, "admin"),     //角色
                    //new Claim(JwtClaimTypes.Role, "user"),     //角色
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);      
            var tokenString = tokenHandler.WriteToken(token);       //得到token的字符串
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    sid = id,
                    name = username,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });            
            

            //return "jwt doLogin success：" + tokenString;
        }

        

        //注解，判断是否登录过
        //默认是通过Http的Authorization头来获取的
        [Authorize]
        public string authz()
        {
            return "jwt user authz";
        }

        //基于角色的授权，注意，区分大小写
        [Authorize(Roles = "admin")]
        public string role()
        {
            return "jwt user admin";
        }

        
        //基于策略的授权，注意，必须注册策略本身，否则启动就报错
        [Authorize(Policy = Permissions.UserRead)]
        public string policy()
        {
            return "jwt user read by policy";
        }

        //获取用户基本信息（如果cookie过期，得到的就是null）
        public string getUserInfo(){
             
             //var username = httpContext.User.Identity.Name;
             var username  = "";
            return "jwt getUserInfo:" + username;
        }
    }
}