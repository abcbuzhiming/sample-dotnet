# SampleAspNetTHULAC
为THULAC分词搭建了一个Http的接口

# 说明文件
* 本演示程序演示C#代码如何调用THULAC分词器功能
* 本演示程序基于THULAC提供的链接库版本的功能完成
* 本演示代码基于Asp.net Core 2.2版本，提供Swagger UI演示分词器功能


## 核心文件说明
* libthulac.dll，Windows下的THULAC分词器动态链接库
* libthulac.so，类Unix系统下的THULAC分词器动态链接库
* models目录，THULAC训练好的模型文件目录
* THULAC\Segmentation.cs,调用libthulac的工具类
* Controllers\SampleController.cs,调用Segmentation的MVC控制器


## 准备工作
* 确保系统上有donet core，可在命令行下输入donte --info检查是否已经安装，没有则请在以下地址下载：https://dotnet.microsoft.com/download

* 如果你将压缩包直接解压到windows的D盘根目录下，即你的项目起始路径是D:\SampleAspNetTHULAC，则不需要做其它操作。如果不是，则请进入源码HULAC\Segmentation.cs文件
  * 修改所有导入DllImport导入链接库的路径为你自己的路径
  * 修改init(model_path: @"D:/SampleAspNetTHULAC/models")，载入模型的路径改为你自己的路径


## 启动
* 命令行切换到SampleAspNetTHULAC路径下
* 执行命令dotnet run。
* 访问地址： http://localhost:5000/swagger/index.html。/Sample/seq分词接口

## 注意事项
* windows系统下，类Unix系统(Linux,OSX,BSD,Unix)下需要切换使用不同的动态链接库，libthulac.dll是Windows版本的，libthulac.so是类Unix版本
* THULAC极其消耗内存，初始载入800MB，虚拟内存在linux下直接超过了20GB，建议单独部署这个服务
* 如果要移植功能到别的项目，你只需要libthulac.dll,libthulac.so,models目录,THULAC\Segmentation.cs这几个就可以了
* libthulac.dll的依赖。生成dll后由Dependency Walker可以发现其依赖另外以下dll：
libgcc_s_seh-1.dll，libstdc++-6.dll，libwinpthread-1.dll。以上三者是MIinGW带的dll。
KERNEL32.DLL，MSVCRT.DLL，USER32.DLL。系统自带的dll。
需要把libgcc_s_seh-1.dll，libstdc++-6.dll，libwinpthread-1.dll这3个dll放在项目根目录下，或者，拷贝到system32目录下去，或者在系统变量Path里增加MinGW/bin目录。否则项目会出现无法装载dll的报错