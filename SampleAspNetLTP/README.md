# SampleAspNetLTP
为哈工大LTP搭建了一个Http的接口
访问地址: http://localhost:5000/swagger/index.html ; http://localhost:5000/LTP/swagger/index.html

## 参考
https://github.com/HIT-SCIR/ltpcsharp

# 说明文件
* 本演示程序演示C#代码如何调用 哈工大LTP 的分词，词性标注等功能
* 本演示程序基于 哈工大LTP 提供的链接库版本的功能完成
* 本演示代码基于Asp.net Core 2.2版本，提供Swagger UI演示分词器功能


## 坑
* C#不能使用C++特有的类型Vector<>。因此这里必须修改C++代码。


