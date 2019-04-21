# 基于.Net Core和Visual Studio建立的Asp.Net项目模板

# 版本
基于.net core 2.x

## 资源占用
.net core在linux下的内存占用，启动时大约50M左右。访问一次后升高到70M左右

## 项目简介
* SampleWebApplicationEmpty
空项目模板

* SampleWebApplication
Web应用模板

* SampleWebApplicationApi
API项目模板

* SampleWebApplicationMvc
完整的MVC项目模板

* SampleWebApplicationWithAngular
MVC + Angular 项目模板

## 项目的配置
每个项目都有一个launchSettings.json，这个东西决定着项目使用何种配置启动
```json
{
  "iisSettings": {			//IIS的配置
    "windowsAuthentication": false, 		//是否使用windows身份验证
    "anonymousAuthentication": true, 		//是否开启所有人均可通过
    "iisExpress": {
      "applicationUrl": "http://localhost:63704",		//http地址和端口
      "sslPort": 44315		//设置了SSL端口则会强制开始SSL
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "SampleWebApplicationMvc": {		//以进程方式启动(自带http服务器)
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",		//http和https的端口
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```


## 项目的区别
项目的启动入口是Program.cs，而主要的不同在Startup.cs里