namespace Betsson_EscapeMines.Core.EscapeMinesExceptions
{
    public class InvalidExitPointException : EscapeMinesBaseException
    {
        public InvalidExitPointException()
        {
        }

        public InvalidExitPointException(string message) : base(message)
        {
        }

    }
}
