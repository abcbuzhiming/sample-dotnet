# SampleAspNetSwagger
Asp.Net Core 2.2 使用Swagger UI范例，Swagger的库是Swashbuckle.AspNetCore

## 要点
* 和Java环境下的Swagger是通过自己的注解来实现功能不一样，asp.net环境下是依赖asp.net自身的功能注解来实现功能
* 方法名上必须有HttpAction注解，比如HttpGet,HttpPost，否则启动异常

## 访问UI的地址
http://localhost:5000/swagger/index.html