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

## C++代码改造
```C++
int segmentor_segment_csharp(void * segmentor, const char *line,char * result_str) {
  std::cout << "start work" << "\r\n";
  std::string str(line);
  std::cout << line << "\r\n";
  std::cout << str << "\r\n";
  if (str.empty()) {
    return 0;
  }
  std::vector<std::string> words;
  __ltp_dll_segmentor_wrapper* wrapper = 0;
  wrapper = reinterpret_cast<__ltp_dll_segmentor_wrapper*>(segmentor);
  int count =  wrapper->segment(str.c_str(), words);

  std::cout << "echo start" << "\r\n";
  std::string tmpStr;		//把分解的字符再拼起来以传出去
  for (int i = 0; i < count; i++){
    std::cout << words[i] << "\r\n";
	tmpStr.append(words[i]);
	tmpStr.append(" "); 
  }
  std::cout << "echo end" << "\r\n";

  //strcpy(result_str, tmpStr.c_str());
  std::cout << "tmpStr length:" << tmpStr.length() << "\r\n";
  std::cout << "copy before:" << result_str << "\r\n";
  std::memcpy(result_str, tmpStr.c_str(), tmpStr.length());
  //std::cout << "calloc:" << static_cast<const void *>(result_str) << "\r\n";
  std::cout << "copy result:" << result_str << "\r\n";
  return count;
}
```