using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Betsson_EscapeMines.Core.Exceptions
{
    public class InvalidMoveCommandException : EscapeMinesBaseException
    {
        public InvalidMoveCommandException()
        {
        }

        public InvalidMoveCommandException(string message) : base(message)
        {
        }

    }
}
