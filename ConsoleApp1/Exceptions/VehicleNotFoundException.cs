using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class VehicleNotFoundException: Exception
    {
        public VehicleNotFoundException() { }

        public VehicleNotFoundException(string message)
            : base(message)
        {
        }

        public VehicleNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
