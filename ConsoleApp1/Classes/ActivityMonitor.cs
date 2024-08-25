using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1.Classes
{
    internal class ActivityMonitor
    {

        private Timer _timer;
        private int _timeoutDuration;
        private object _lock = new object();

        
        private CancellationTokenSource _cts;
        public event Action OnTimeout;

        public ActivityMonitor(int timeoutMinutes = 10)
        {
            _timeoutDuration = timeoutMinutes * 60 * 1000;
          //  _isRunning = false;
        }

        public void StartInactivtyTimer()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            Task.Delay(TimeSpan.FromMinutes(5), _cts.Token).ContinueWith(task =>
            {
                if (!task.IsCanceled)
                {
                    OnTimeout?.Invoke();
                }
            });
        }

        public void StopInactivtyTimer()
        {
            _cts?.Cancel();
        }

        public class InactivityTimeOutException : Exception
        {
            public InactivityTimeOutException() : base("Session timed out due to inactivity")
            {
            }

            public InactivityTimeOutException(string message) : base(message)
            {
            }

        }
    }
}
