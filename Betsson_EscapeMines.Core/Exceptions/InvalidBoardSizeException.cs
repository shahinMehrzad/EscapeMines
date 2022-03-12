namespace Betsson_EscapeMines.Core.EscapeMinesExceptions
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
