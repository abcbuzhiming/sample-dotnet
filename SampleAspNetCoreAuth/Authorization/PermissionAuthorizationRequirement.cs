using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SampleAspNetCoreAuth.Authorization
{
    /// <summary>
    /// 授权要求接口实现，其实现决定通过认证所需要拥有的特性
    /// </summary>
    /// <remark>特性可以是权限，可以是别的属性等等</remark>
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public PermissionAuthorizationRequirement(string name)
        {
            Name = name;
        }

        
    }
}