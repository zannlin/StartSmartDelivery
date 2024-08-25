using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class InvalidTypeException : Exception
    {
        public InvalidTypeException() { }

        public InvalidTypeException(string message) : base(message) {
            
        }

        public InvalidTypeException(string message, Exception inner) : base(message, inner) { }
    }
}
