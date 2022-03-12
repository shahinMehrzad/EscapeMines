using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Betsson_EscapeMines.EscapeMinesExceptions
{
    public class InvalidBoardSizeException : EscapeMinesBaseException
    {
        public InvalidBoardSizeException()
        {
        }

        public InvalidBoardSizeException(string message) : base(message)
        {
        }

    }
}
