using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class VehicleNotAssignedException : Exception
    {
        public VehicleNotAssignedException() { }

        public VehicleNotAssignedException(string message) { }

        public VehicleNotAssignedException(string message, Exception inner) : base(message, inner) { }
    }
}
