using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBackgroundTasksInWebHost.Services
{
    public interface IBackgroundTaskQueue
    {
        //入队
        void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);

        //出队
        Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    }

    //任务队列，并用信号量控制访问的线程数
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        //线程安全队列
        private ConcurrentQueue<Func<CancellationToken, Task>> _workItemsQueue = new ConcurrentQueue<Func<CancellationToken, Task>>();
        private SemaphoreSlim _signal = new SemaphoreSlim(0); //信号量轻量级版本

        public void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            _workItemsQueue.Enqueue(workItem); //加入队列
            _signal.Release();     //释放1个线程，即可进行处理
        }

        public async Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);        //异步等待信号量，同时观察cancellationToken
            _workItemsQueue.TryDequeue(out var workItem);      //出队列

            return workItem;
        }
    }
}