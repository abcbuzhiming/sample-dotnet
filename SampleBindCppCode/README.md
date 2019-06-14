# SampleBindCppCode
该项目展示如果用C#调用C/C++的动态链接库函数

## 注意点
* 动态链接库有目标平台区别，windows下是dll，Unix，Linux，OSX是so文件
* 调用dll出错时，可能字节退出而捕获不到任何异常
* 尤其要注意C#和C/C++之间的字符串编码不同问题
