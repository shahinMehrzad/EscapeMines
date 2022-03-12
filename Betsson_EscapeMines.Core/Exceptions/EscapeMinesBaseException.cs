using System;
using System.Runtime.Serialization;

namespace Betsson_EscapeMines.Core.Exceptions
{
    public class EscapeMinesBaseException : Exception
    {
        public EscapeMinesBaseException()
        {
        }

        public EscapeMinesBaseException(string message) : base(message)
        {
        }

        public EscapeMinesBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EscapeMinesBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
