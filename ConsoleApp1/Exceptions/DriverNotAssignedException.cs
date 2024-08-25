using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class DriverNotAssignedException : Exception
    {
        public DriverNotAssignedException() { }

        public DriverNotAssignedException(string message) { }

        public DriverNotAssignedException(string message, Exception inner) : base(message, inner) { }
    }
}
