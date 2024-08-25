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
        private Thread _monitorThread;
        private int _timeoutDuration;
        private bool _isRunning;
        private DateTime _lastActivityTime;
        private object _lock = new object();

        public event Action OnTimeout;

        public ActivityMonitor(int timeoutMinutes = 10)
        {
            _timeoutDuration = timeoutMinutes * 60 * 1000; // Convert minutes to milliseconds
            _isRunning = false;
            _lastActivityTime = DateTime.Now;
        }

        public void StartInactivityMonitor()
        {
            _isRunning = true;
            _monitorThread = new Thread(MonitorInactivity);
            _monitorThread.IsBackground = true; // Allows the thread to exit when the application exits
            _monitorThread.Start();
        }

        public void ResetTimer()
        {
            lock (_lock)
            {
                _lastActivityTime = DateTime.Now;
            }
        }

        public void StopMonitor()
        {
            _isRunning = false;
        }

        private void MonitorInactivity()
        {
            while (_isRunning)
            {
                lock (_lock)
                {
                    if ((DateTime.Now - _lastActivityTime).TotalMilliseconds >= _timeoutDuration)
                    {
                        OnTimeout?.Invoke();
                        _isRunning = false;
                    }
                }
                Thread.Sleep(1000); // Check every second
            }
        }
    }
}
