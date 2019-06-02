# SampleAspNetSwagger
Asp.Net Core 2.2 使用Swagger UI范例，Swagger的库是Swashbuckle.AspNetCore

## 参考
[Swashbuckle.AspNetCore github](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
[Swagger/OpenAPI](https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/web-api-help-pages-using-swagger)


## 要点
* 和Java环境下的Swagger是通过自己的注解来实现功能不一样，asp.net环境下是依赖asp.net自身的功能注解来实现功能
* 方法名上必须有HttpAction注解，比如HttpGet,HttpPost，否则启动异常
* swagger上方法和参数的注释依赖C#风格的注释，需要生成xml来展示，所以，需要在csproj文件的PropertyGroup节点中加入以下内容
```xml
  <PropertyGroup>
    <!-- 生成xml文档 -->
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>

  </PropertyGroup>
```

## 访问UI的地址
http://localhost:5000/swagger/index.html