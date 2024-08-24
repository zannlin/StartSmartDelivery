using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp1.Classes
{
    internal class OperationLogs
    {
        private readonly Thread _monitorThread;
        private bool _isRunning;
        private readonly ConcurrentQueue<string> _logQueue;

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
            _monitorThread.Join(); // Ensures the thread finishes before ending
        }

        public void LogOperation(string operation)
        {
            _logQueue.Enqueue(operation);
        }

        private void MonitorOperations()
        {
            while (_isRunning)
            {
                while (_logQueue.TryDequeue(out string operation))
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

        // Method to retrieve all logs from the queue as a list
        public List<string> GetLogs()
        {
            return _logQueue.ToList();
        }
    }
}
