using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBackgroundTasksInWebHost.Services {
    public interface IBackgroundTaskQueue {
        void QueueBackgroundWorkItem (Func<CancellationToken, Task> workItem);

        Task<Func<CancellationToken, Task>> DequeueAsync (
            CancellationToken cancellationToken);
    }

    public class BackgroundTaskQueue : IBackgroundTaskQueue {
        //线程安全队列
        private ConcurrentQueue<Func<CancellationToken, Task>> _workItemsQueue = new ConcurrentQueue<Func<CancellationToken, Task>> ();
        private SemaphoreSlim _signal = new SemaphoreSlim (0); //信号量轻量级版本

        public void QueueBackgroundWorkItem (Func<CancellationToken, Task> workItem) {
            if (workItem == null) {
                throw new ArgumentNullException (nameof (workItem));
            }

            _workItemsQueue.Enqueue (workItem); //添加元素
            _signal.Release ();
        }

        public async Task<Func<CancellationToken, Task>> DequeueAsync (CancellationToken cancellationToken) {
            await _signal.WaitAsync (cancellationToken);
            _workItemsQueue.TryDequeue (out var workItem);

            return workItem;
        }
    }
}