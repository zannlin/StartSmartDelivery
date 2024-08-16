using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class InvalidTypeException : Exception
    {
        //TODO - Choose and implement error handling 

        //Edit Default Constructor?
        public InvalidTypeException() { }
        //Edit Constructor with one paramater (message)
        public InvalidTypeException(string message) : base(message) { }
        //Edit Constructor with two paramaters (message, inner)
        public InvalidTypeException(string message, Exception inner) : base(message, inner) { }
    }
}
