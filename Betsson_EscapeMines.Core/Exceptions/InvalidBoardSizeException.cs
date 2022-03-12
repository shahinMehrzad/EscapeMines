namespace Betsson_EscapeMines.Core.Exceptions
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
