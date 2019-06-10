# SampleAspNetCoreAuth
Asp.Net Core的认证和授权

## 参考
[ASP.NET Core 安全性概述](https://docs.microsoft.com/zh-cn/aspnet/core/security/)
[ASP.NET Core 认证与授权[1]:初识认证](https://www.cnblogs.com/RainingNight/archive/2017/09/26/7512903.html)
[ASP.NET Core 认证与授权[2]:Cookie认证](https://www.cnblogs.com/RainingNight/p/cookie-authentication-in-asp-net-core.html)
[ASP.NET Core 认证与授权[3]:OAuth & OpenID Connect认证](https://www.cnblogs.com/RainingNight/p/oidc-authentication-in-asp-net-core.html)
[ASP.NET Core 认证与授权[4]:JwtBearer认证](https://www.cnblogs.com/RainingNight/p/jwtbearer-authentication-in-asp-net-core.html)
[ASP.NET Core 认证与授权[5]:初识授权](https://www.cnblogs.com/RainingNight/p/authorization-in-asp-net-core.html)
[ASP.NET Core 认证与授权[6]:授权策略是怎么执行的？](https://www.cnblogs.com/RainingNight/p/authorize-how-to-work-in-asp-net-core.html)
[ASP.NET Core 认证与授权[7]:动态授权](https://www.cnblogs.com/RainingNight/p/dynamic-authorization-in-asp-net-core.html)
[asp.net core 2.0的认证和授权](https://www.cnblogs.com/axzxs2001/p/7482771.html)

## 项目说明

## 基于cookie
* 使用StartupCookie.cs作为配置文件
* 范例控制器在Controllers/Cookie中

## 基于jwt(http header中传递token)
* 使用StartupJwt.cs作为配置文件
* 范例控制器在Controllers/Jwt中

## cookie认证模式下不进行跳转
https://stackoverflow.com/questions/32863080/how-to-remove-the-redirect-from-an-asp-net-core-webapi-and-return-http-401

## 总结
* 官方推荐的解决方案就是基于策略，你注册一个策略，然后在策略的处理器里决定当前的用户到底有没有权限，为此你可以查数据库查缓存。但是缺陷就是每个策略都要注册1次才能用
* 更简单直接的方法就是自定义一个授权过滤器，在它的处理方法里你也是可以相干啥就干啥