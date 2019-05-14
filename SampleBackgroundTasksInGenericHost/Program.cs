using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleBackgroundTasksInGenericHost.Services;


namespace SampleBackgroundTasksInGenericHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello SampleBackgroundTasksInGenericHost");

            var host = new HostBuilder()
                .ConfigureLogging((hostContext, config) =>
                {
                    config.AddConsole();
                    config.AddDebug();
                })
                .ConfigureHostConfiguration(config =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    #region snippet1
                    services.AddHostedService<TimedHostedService>();        //注册后台服务- 带有定时器的后台任务
                    #endregion

                    #region snippet2            
                    //services.AddHostedService<ConsumeScopedServiceHostedService>();       //在后台任务中使用有作用域的服务
                    //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
                    #endregion

                    #region snippet3
                    services.AddSingleton<MonitorLoop>();       //添加后台任务，依赖后台任务服务
                    services.AddHostedService<QueuedHostedService>();       //基于队列的后台任务
                    services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();     //单例模式
                    #endregion
                })
                .UseConsoleLifetime()
                .Build();

            using (host)
            {
                // Start the host
                await host.StartAsync();

                // Monitor for new background queue work items
                var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
                monitorLoop.StartMonitorLoop();

                // Wait for the host to shutdown
                await host.WaitForShutdownAsync();
            }

        }

        
    }
}
