namespace Betsson_EscapeMines.Core.Exceptions
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
