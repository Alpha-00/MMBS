using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMBS
{
    static class AsyncHelpers
    {

        public static void RunSync(Func<Task> task)
        {
            var currentContext = SynchronizationContext.Current;
            var customContext = new CustomSynchronizationContext(task);

            try
            {
                SynchronizationContext.SetSynchronizationContext(customContext);
                customContext.Run();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(currentContext);
            }
        }

        public static T RunSync<T>(Func<Task<T>> task)
        {
            T result = default;
            RunSync(async () => { result = await task(); });
            return result;
        }

        class CustomSynchronizationContext : SynchronizationContext
        {
            readonly ConcurrentQueue<Tuple<SendOrPostCallback, object>> _items = new ConcurrentQueue<Tuple<SendOrPostCallback, object>>();
            readonly AutoResetEvent _workItemsWaiting = new AutoResetEvent(false);
            readonly Func<Task> _task;
            ExceptionDispatchInfo _caughtException;
            bool _done;

            public CustomSynchronizationContext(Func<Task> task) =>
                _task = task ?? throw new ArgumentNullException(nameof(task), "Please remember to pass a Task to be executed");

            public override void Post(SendOrPostCallback function, object state)
            {
                _items.Enqueue(Tuple.Create(function, state));
                _workItemsWaiting.Set();
            }

            public void Run()
            {
                async void PostCallback(object _)
                {
                    try
                    {
                        await _task().ConfigureAwait(false);
                    }
                    catch (Exception exception)
                    {
                        _caughtException = ExceptionDispatchInfo.Capture(exception);
                        throw;
                    }
                    finally
                    {
                        Post((x) => _done = true, null);
                    }
                }

                Post(PostCallback, null);

                while (!_done)
                {
                    if (_items.TryDequeue(out var task))
                    {
                        task.Item1(task.Item2);
                        if (_caughtException == null)
                        {
                            continue;
                        }
                        _caughtException.Throw();
                    }
                    else
                    {
                        _workItemsWaiting.WaitOne();
                    }
                }
            }

            public override void Send(SendOrPostCallback function, object state) => throw new NotSupportedException("Cannot send to same thread");

            public override SynchronizationContext CreateCopy() => this;
        }
    }
}
