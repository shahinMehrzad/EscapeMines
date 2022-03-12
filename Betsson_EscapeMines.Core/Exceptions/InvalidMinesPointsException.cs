namespace Betsson_EscapeMines.Core.Exceptions
{
    public class InvalidMinesPointsException : EscapeMinesBaseException
    {
        public InvalidMinesPointsException()
        {
        }

        public InvalidMinesPointsException(string message) : base(message)
        {
        }

    }
}
