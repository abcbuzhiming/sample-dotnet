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
* 以下是分词器源码的改写
```C++
// 在 src/segmentor/segment_dll.h源码中加入以下函数声明
SEGMENTOR_DLL_API int segmentor_segment_csharp(void * parser,
												const char *line,
												char * result_str);

// 在 src/segmentor/segment_dll.cpp源码中加入以下函数定义
int segmentor_segment_csharp(void * segmentor, const char *line,char * result_str) {

  std::string str(line);
  if (str.empty()) {
    return 0;
  }
  std::vector<std::string> words;
  __ltp_dll_segmentor_wrapper* wrapper = 0;
  wrapper = reinterpret_cast<__ltp_dll_segmentor_wrapper*>(segmentor);
  int count =  wrapper->segment(str.c_str(), words);

  std::string tmpStr;		//把分解的字符再拼起来以传出去
  for (int i = 0; i < count; i++){
    std::cout << words[i] << "\r\n";
	tmpStr.append(words[i]);
	tmpStr.append(" "); 
  } 
  
  //strcpy(result_str, tmpStr.c_str());
  //std::cout << "tmpStr length:" << tmpStr.length() << "\r\n";
  //std::cout << "copy before:" << result_str << "\r\n";
  std::memcpy(result_str, tmpStr.c_str(), tmpStr.length());
  //std::cout << "calloc:" << static_cast<const void *>(result_str) << "\r\n";
  //std::cout << "copy result:" << result_str << "\r\n";
  return count;
}
```

* 以下是词性分析器的源码改写
```C++
// 在 src/postagger/postag_dll.h源码中加入以下函数声明
POSTAGGER_DLL_API int postagger_postag_csharp(void * postagger,
	const char *source,
	char * tags_str);


// 在 src/postagger/postag_dll.cpp源码中加入以下函数定义
int postagger_postag_csharp(void * postagger,
	const char *source,
	char * tags_str) {
	//字符串转vector<string>,来自src\utils\strutils.hpp的split函数
	int maxsplit = -1;
	std::string str(source);
	int numsplit = 0;
	int len = str.size();
	size_t pos;
	for (pos = 0; pos < str.size() && (str[pos] == ' ' || str[pos] == '\t'
		|| str[pos] == '\n' || str[pos] == '\r'); ++pos);
	str = str.substr(pos);

	std::vector<std::string> ret;
	ret.clear();
	while (str.size() > 0) {
		pos = std::string::npos;

		for (pos = 0; pos < str.size() && (str[pos] != ' '
			&& str[pos] != '\t'
			&& str[pos] != '\r'
			&& str[pos] != '\n'); ++pos);

		if (pos == str.size()) {
			pos = std::string::npos;
		}

		if (maxsplit >= 0 && numsplit < maxsplit) {
			ret.push_back(str.substr(0, pos));
			++numsplit;
		}
		else if (maxsplit >= 0 && numsplit == maxsplit) {
			ret.push_back(str);
			++numsplit;
		}
		else if (maxsplit == -1) {
			ret.push_back(str.substr(0, pos));
			++numsplit;
		}

		if (pos == std::string::npos) {
			str = "";
		}
		else {
			for (; pos < str.size() && (str[pos] == ' '
				|| str[pos] == '\t'
				|| str[pos] == '\n'
				|| str[pos] == '\r'); ++pos);
			str = str.substr(pos);
		}
	}

	if (0 == ret.size()) {
		return 0;
	}

	for (int i = 0; i < ret.size(); ++i) {
		if (ret[i].empty()) {
			return 0;
		}
	}

	__ltp_dll_postagger_wrapper* wrapper = 0;
	wrapper = reinterpret_cast<__ltp_dll_postagger_wrapper*>(postagger);
	std::vector<std::string> tags;		//词性标记返回值
	int count = wrapper->postag(ret, tags);

	std::string tmpStr;		//把分解的字符再拼起来以传出去
	for (int i = 0; i < count; i++) {
		//std::cout << tags[i] << "\r\n";
		tmpStr.append(tags[i]);
		tmpStr.append(" ");
	}
	std::memcpy(tags_str, tmpStr.c_str(), tmpStr.length());

	return count;
}
```