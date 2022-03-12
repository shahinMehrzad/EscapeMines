using System;
using System.Runtime.Serialization;

namespace Betsson_EscapeMines.Core.Exceptions
{
    public class InvalidTurtlePointException : EscapeMinesBaseException
    {
        public InvalidTurtlePointException()
        {
        }

        public InvalidTurtlePointException(string message) : base(message)
        {
        }

    }
}
