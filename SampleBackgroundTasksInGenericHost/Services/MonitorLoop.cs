using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleBackgroundTasksInGenericHost.Services
{
    //监控循环
    public class MonitorLoop
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly ILogger _logger;
        private readonly CancellationToken _cancellationToken;


public MonitorLoop(IBackgroundTaskQueue taskQueue, ILogger<MonitorLoop> logger, IApplicationLifetime applicationLifetime)
        {
            _taskQueue = taskQueue;
            _logger = logger;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public void StartMonitorLoop()
        {
            // Run a console user input loop in a background thread
            Task.Run(() => Monitor());
        }

        public void Monitor()
        {
            Console.WriteLine();
            //Console.WriteLine("Tap W to add a work item to the background queue ...");
            Console.WriteLine("按下W键添加一个工作任务到后台队列 ...");
            Console.WriteLine();

            while (!_cancellationToken.IsCancellationRequested)
            {
                var keyStroke = Console.ReadKey();      //获得键盘输入

                if (keyStroke.Key == ConsoleKey.W)      //如果输入是W
                {
                    // Enqueue a background work item
                    _taskQueue.QueueBackgroundWorkItem(async token =>
                    {
                        var guid = Guid.NewGuid().ToString();

                        for (int delayLoop = 0; delayLoop < 3; delayLoop++)
                        {
                            _logger.LogInformation(
                                $"Queued Background Task {guid} is running. {delayLoop}/3");
                            await Task.Delay(TimeSpan.FromSeconds(5), token);
                        }

                        _logger.LogInformation(
                            $"Queued Background Task {guid} is complete. 3/3");
                    });
                }
            }
        }
    }
}