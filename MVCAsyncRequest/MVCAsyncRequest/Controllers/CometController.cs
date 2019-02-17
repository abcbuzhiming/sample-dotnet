using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/**
 * 
[用 ASP.NET MVC 实现基于 XMLHttpRequest long polling（长轮询） 的 Comet](https://www.cnblogs.com/dudu/archive/2011/10/17/mvc_comet_long_polling.html)
[在 ASP.NET MVC 中使用异步控制器](https://msdn.microsoft.com/library/ee728598(v=vs.100).aspx)
[详解 ASP.NET异步](https://www.cnblogs.com/wisdomqq/archive/2012/03/29/2417723.html)
要点：
    1.继承自AsyncController
    2.方法有两个，一个以Async结尾(不返回任何结果)，一个以Completed结尾(实际放回结果的方法)。注意，实际请求地址是不带这两个后缀的，比如下例中，实际请求地址是/Comet/LongPolling
    3.AsyncTimeout特性设置服务端异步超时时间，单位毫秒，超过此时间还未调用Completed方法的话，系统会自动抛出超时错误
备注：
    传统的webform可以使用IHttpAsyncHandler来实现异步，这里没有演示，网上有代码
    MVC除了AsyncController这种方式外，还可以使用await来实现异步，见AwaitController

*/
namespace MVCAsyncRequest.Controllers
{
    public class CometController : AsyncController
    {
        //LongPolling Action 1 - 处理客户端发起的请求
        [AsyncTimeout(30000)]
        public void LongPollingAsync()
        {
            //计时器，5秒后触发一次Elapsed事件
            System.Timers.Timer timer = new System.Timers.Timer(5000);

            //AsyncManager.Timeout = 300;       //设置异步超时时间，单位毫秒，超过此时间还未调用Completed方法的话，系统会自动
            //告诉ASP.NET接下来将进行异步操作
            AsyncManager.OutstandingOperations.Increment();
            
        
            //订阅至计时器的Elapsed事件
            timer.Elapsed += (sender, e) =>
            {
                //保存将要传递给LongPollingCompleted的参数
                AsyncManager.Parameters["now"] = e.SignalTime;
                //告诉ASP.NET异步操作已完成，进行LongPollingCompleted方法的调用
                AsyncManager.OutstandingOperations.Decrement();
            };
            //启动计时器
            timer.Start();
        }

        //LongPolling Action 2 - 异步处理完成，向客户端发送响应
        public ActionResult LongPollingCompleted(DateTime now)
        {
            return Json(new
            {
                d = now.ToString("MM-dd HH:mm:ss ") +
                    "-- Welcome to cnblogs.com!"
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}