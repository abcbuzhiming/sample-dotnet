# SampleAspNetCache
Asp.Net Core的缓存用例

## 参考
[缓存在内存中 ASP.NET Core](https://docs.microsoft.com/zh-cn/aspnet/core/performance/caching/memory)
[分布式缓存在 ASP.NET Core 中](https://docs.microsoft.com/zh-cn/aspnet/core/performance/caching/distributed)

## 依赖
* .net framework需要System.Runtime.Caching依赖库
* .net core需要加依赖包Microsoft.Extensions.Caching.Memory，.net core 2.1不需要额外安装

## 总结
* asp.net默认支持内存缓存，redis，sql server三种缓存
* asp.net有能提供响应缓存的中间件
* 缓存可以设定决定过期时间，可调过期时间
* 缓存在被删除时可设定回调方法
* 可设置单个缓存的大小，并供依赖注入
* 缓存可互相依赖，关联删除
* 分布式缓存有内存(NCache),SQlServer,Redis三种方案