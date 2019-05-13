using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleBackgroundTasksInWebHost.Services
{
    public class TimedHostedService: IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(5));       //5秒执行1次DoWork，参数1是任务函数，参数2是传给任务函数用的值，参数3等待多久启动，参数4是间隔时间

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Timed Background Service is working." + DateTime.Now.ToString());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}