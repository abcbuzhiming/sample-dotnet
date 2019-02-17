using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCAsyncRequest.Controllers
{
    public class AwaitController : Controller
    {
        
        //Task中的泛型可以是任意一种类型，代表你返回的实际结果，这里我们用string
        public async Task<string> LongPolling()
        {
            //这里实现了一个匿名的方法，用await关键字等待它返回结果，你可以在该方法里执行长期操作。
            //注意这里是Task实现不带超时设置，实际开发时你可能需要用Task.Wait来实现带超时返回的任务，以防止任务始终不完成，造成系统卡死
            return await Task.Run<string>(() =>
            {
                
                Debug.WriteLine("等待5秒");
                Thread.Sleep(5000);
                Debug.WriteLine("等待结束");
                return "hello Async Await";
            });
        }
    }
}