using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class OperationLogs
    {
        private readonly Thread _monitorThread;
        private bool _isRunning;

        private ConcurrentQueue<string> _logQueue;


        public OperationLogs()
        {
            _isRunning = true;
            _monitorThread = new Thread(new ThreadStart(MonitorOperations));
            _logQueue = new ConcurrentQueue<string>();
            
        }

        public void Start()
        {
            _monitorThread.Start();
        }

        public void Stop()
        {
            _isRunning = false;
            _monitorThread.Join(); //this makes the thread finish before ending
        }

        public void LogOperation(string operation)
        {
            _logQueue.Enqueue(operation);
        }

        private void MonitorOperations()
        {
            while (_isRunning)
            {
                    while(_logQueue.TryDequeue(out string operation))
                    {
                        HandleOperation(operation);
                    }
                Thread.Sleep(1000); // Adjusts how often the thread should run
            }
        }

        private void HandleOperation(string operation)
        {
           
            Console.WriteLine($"Operation Handled: {operation}");
        }
    }
}
