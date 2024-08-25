using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class FailedValidationException : Exception
    {
        public FailedValidationException() { }

        public FailedValidationException(string message):base(message) {  }

        public FailedValidationException(string message, Exception inner) : base(message, inner) {  }
    }
}
