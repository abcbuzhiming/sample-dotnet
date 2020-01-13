# .net framework使用串口的范例
从2.0开始，加入了串口读写类SerialPort

## 参考
[C#串口通信-示例](https://www.cnblogs.com/chinahunter/p/10934387.html)


## 发现的坑
### 接收数据时会卡住
问题的现象：
当接收的数据间隔时间很短(100ms或更短)，并且带有换行符"\n"的时候，
如果操作ui把接收并显示数据的textbox清空，然后整个程序会卡住，要等很久才会恢复(甚至恢复不了卡到死)

现象的分析:
通过打印日志分析得出，当清空textbox后，SerialDataReceivedEventHandler 接收事件就不被触发，要停止发送方的数据，等待一段时间，才会触发这个事件，然后一次性的读取到这段时间的全部数据；
在此过程中，发现程序内存占用急速上升，并且UI也卡死了。并且整个卡死过程不会触发读超时(这就很奇怪)


查找到的资料
[SerialPort.DataReceived 事件](https://docs.microsoft.com/zh-cn/dotnet/api/system.io.ports.serialport.datareceived)
此文中提到：不保证为每个接收的字节引发 DataReceived 事件。 使用 BytesToRead 属性来确定要在缓冲区中读取的数据量

推导：难道是数据接收的太多，SerialPort急着缓存数据去了，没有触发事件，所以程序就卡在那里了？

[SerialPort.Read 方法](https://docs.microsoft.com/zh-cn/dotnet/api/system.io.ports.serialport.read)
此文提到: 由于 SerialPort 类会缓冲数据，并且 BaseStream 属性中包含的流不会，这两个可能与可读取的字节数有关。 BytesToRead 属性可以指示存在要读取的字节，但 BaseStream 属性中包含的流可能无法访问这些字节，
因为这些字节已缓冲到 SerialPort 类中。
读取的字节数 count 等于时，Read 方法不会阻止其他操作，但串行端口仍有可用的未读字节

[Serial Port Read Hangs](https://social.msdn.microsoft.com/Forums/en-US/0ae1d0e3-3853-4b99-b486-f9944b5cf907/serial-port-read-hangs?forum=Vsexpressvb)
这篇文章提到如果 SerialPort.ReadTimeout 设置为-1，会造成阻塞。
[SerialPort Read method hanging](https://social.msdn.microsoft.com/Forums/en-US/32281c77-f3dc-4d6d-b675-3592d86a0288/serialport-read-method-hanging?forum=csharpgeneral)
这篇文章也提到了read本身是个阻塞方法

不过我就算设置成100ms也没有引发读超时异常啊，而且我阻塞的位置都还没到read方法，是根本没触发 DataReceived 事件


[Serial Port - ReadLine Vs Read methods - what to use](https://social.msdn.microsoft.com/Forums/vstudio/en-US/2e881834-5b68-4935-a185-c90e71aff7ad/serial-port-readline-vs-read-methods-what-to-use?forum=netfxbcl)
这篇文章把微软的串口操作api批判了一通：
```
is a blocking method, which does not return before "count" number of bytes are received. It is not!. If there are bytes available on the serial port, Read returns up to "count" bytes, but will not block (wait) for the remaining bytes. If there are no bytes available on the serial port, Read will block until at least one byte is available on the port, up until the ReadTimeout milliseconds have elapsed, at which time a TimeoutException will be thrown. Unless you check the actual number of received bytes, you may believe that all bytes in your buffer are valid. This may not be the case!

PS! SerialPort in .Net 3.5 is so full of errors that it may be regarded as useless. Use .Net 2.0 or a third party DLL.
```

[If you *must* use .NET System.IO.Ports.SerialPort ](https://www.sparxeng.com/blog/software/must-use-net-system-io-ports-serialport)
[Reading line-by-line from a serial port (or other byte-oriented stream) ](https://www.sparxeng.com/blog/software/reading-lines-serial-port)
这两篇文章把.net的 System.IO.Ports.SerialPort 大势批判了一通，认为他们是科学家设计出来的，他们既不了解串行通信的特性，也不了解常见的用例，充满问题的api,建议用第三方库或者c++/cli。
作者认为：
DataReceived事件（100％冗余，也完全不可靠）
BytesToRead属性（完全不可靠）
Read，ReadExisting，ReadLine方法（处理错误完全错误，并且是同步的）
PinChanged事件（与您可能想知道的每件事有关的顺序混乱）

作者认为以下的接收数据代码是错误的
```C#
port.DataReceived += port_DataReceived;

// (later, in DataReceived event)
try {
    byte[] buffer = new byte[port.BytesToRead];
    port.Read(buffer, 0, buffer.Length);
    raiseAppSerialDataEvent(buffer);
}
catch (IOException exc) {
    handleAppSerialError(exc);
}
```

作者认为以下的方式是正确的方法，与使用底层Win32 API的方式相匹配

```C#
byte[] buffer = new byte[blockLimit];
Action kickoffRead = null;
kickoffRead = delegate {
    port.BaseStream.BeginRead(buffer, 0, buffer.Length, delegate (IAsyncResult ar) {
        try {
            int actualLength = port.BaseStream.EndRead(ar);
            byte[] received = new byte[actualLength];
            Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
            raiseAppSerialDataEvent(received);
        }
        catch (IOException exc) {
            handleAppSerialError(exc);
        }
        kickoffRead();
    }, null);
};
kickoffRead();
```

整个测试下来，发现问题可能还是出在this.Invoke把数据传递给UI上，只要去掉这个，就怎么也不会卡住，不像是SerialPort本身有问题


最终确认：问题是textbox本身的bug，和win10有关
https://social.msdn.microsoft.com/Forums/en-US/695c9f00-4651-4aa4-873a-3b30898e101e/windows-10017763-1809-textboxtext-set-memory-leak?forum=winforms

该讨论放狗用关键字 c# textbox append \r  \n separate hang 搜索到

windows下换行符是"\r\n"，是两个字符，当你一次性的把它们设置到开了多行属性的textbox里时，不会有任何问题，正常换行。
但是当你分开添加的时候，会偶发性的出现界面卡住，内存占用飙升的bug。
该bug似乎是win10独有，疑与最近win10添加了支持类unix系统的换行符有关系。

本程序重现bug的方式
* 点启动，另外一个线程定时的向textbox添加字符串，注意是分开添加的 "\r" 和 "\n"
* 点另外一个按钮，清空 textbox，多点几次，就会出现ui卡住，内存飙升的现象，有时等待一段时间能恢复，有时会卡死不能恢复。

