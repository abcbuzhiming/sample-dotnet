using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleBackgroundTasksInWebHost.Services;
using System.Threading;

namespace SampleBackgroundTasksInWebHost.Controllers
{
    [Route("task")]
    public class TaskController : Controller
    {
        private readonly ILogger _logger;

        //队列
        public IBackgroundTaskQueue Queue { get; }

        public TaskController(ILogger<TaskController> logger, IBackgroundTaskQueue queue)
        {
            _logger = logger;
            Queue = queue;
        }

        [Route("addtask")]
        public string addTask()
        {
            _logger.LogInformation("add task:" + DateTime.Now.ToString());
            Queue.QueueBackgroundWorkItem(async cancellationToken =>
            {
                var guid = Guid.NewGuid().ToString();
                _logger.LogInformation($"Queued Background Task {guid} is start." + DateTime.Now.ToString());
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);       //异步延迟5秒
                _logger.LogInformation($"Queued Background Task {guid} is complete." + DateTime.Now.ToString());
            });

            return "add task success";
        }
    }
}