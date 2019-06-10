using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SampleAspNetCoreAuth.Authorization
{
    /// <summary>
    /// 自定义特性来实现认证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PermissionFilter : Attribute, IAsyncAuthorizationFilter
    {
        /// <summary>
        /// 注解的值
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        public PermissionFilter(string name)
        {
            Name = name;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            Console.WriteLine("PermissionFilter.OnAuthorizationAsync:" + Name);

            var httpContext = context.HttpContext;      //拿到Http上下文
            if(httpContext.User == null){
                Console.WriteLine("httpContext.User is null");
                context.Result = new ForbidResult();
                return Task.CompletedTask;
            }
            var userIdClaim = httpContext.User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                Console.WriteLine("userIdClaim is null");
                context.Result = new ForbidResult();
                return Task.CompletedTask;
            }
            //从这里，引入自定义存储，检测用户是否有足够的权限

            //if (_userStore.CheckPermission(int.Parse(userIdClaim.Value), requirement.Name))
            //{
                //context.Succeed(requirement);
            //}

            /*
            var authorizationService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            var authorizationResult = await authorizationService.AuthorizeAsync(context.HttpContext.User, null, new PermissionAuthorizationRequirement(Name));
            if (!authorizationResult.Succeeded)
            {
                context.Result = new ForbidResult();
            }
             */
            return Task.CompletedTask;
        }
    }
}