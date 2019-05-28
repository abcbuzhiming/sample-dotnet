# SampleAspNetHandleError
Asp.net 错误处理范例演示

## 参考
[异常处理程序 lambda](https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/error-handling)
[.net core 全局异常抓取](https://blog.csdn.net/confused_kitten/article/details/81702861)
[Asp.Net Core异常处理](https://blog.csdn.net/ailanzhe/article/details/79726568)

## 总结
* 异常的处理方式有，UseDeveloperExceptionPage，UseExceptionHandler，UseStatusCodePages中间件
* UseDeveloperExceptionPage开发异常页；UseExceptionHandler定义异常时处理的Action路径(直接输出内容不跳转)；UseStatusCodePages处理400-599异常状态码且内容为空的回应，加上请求码作为内容
* mvc异常过滤器限制（限定action范围内）异常过滤器IExceptionFilter (  A filter that runs after an action has thrown an System.Exception.)，顾，它抓取的范围是Action方法执行过程中出现的未处理的异常，其它异常并不会被该过滤器捕捉到，如身份验证器中的异常，所以用IExceptionFilter做全局异常抓取是有很大局限性的
* 非MVC引起的异常，MVC过滤器是不能捕获异常的，此时应使用自定义异常捕获中间件 Middleware
