# WinForm的换行符bug

## bug的社区讨论
https://social.msdn.microsoft.com/Forums/en-US/695c9f00-4651-4aa4-873a-3b30898e101e/windows-10017763-1809-textboxtext-set-memory-leak?forum=winforms

该讨论放狗用关键字 c# textbox append \r  \n separate hang 搜索到

## bug描述
windows下换行符是"\r\n"，是两个字符，当你一次性的把它们设置到开了多行属性的textbox里时，不会有任何问题，正常换行。
但是当你分开添加的时候，会偶发性的出现界面卡住，内存占用飙升的bug。
该bug似乎是win10独有，疑与最近win10添加了支持类unix系统的换行符有关系。

本程序重现bug的方式
* 点启动，另外一个线程定时的向textbox添加字符串，注意是分开添加的 "\r" 和 "\n"
* 点另外一个按钮，清空 textbox，多点几次，就会出现ui卡住，内存飙升的现象，有时等待一段时间能恢复，有时会卡死不能恢复。