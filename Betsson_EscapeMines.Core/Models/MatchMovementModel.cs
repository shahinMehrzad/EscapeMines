using Betsson_EscapeMines.Core.Enums;

namespace Betsson_EscapeMines.Core.Models
{
    public class MatchMovementModel
    {
        public string Message { get; set; }
        public TurtlePoint TurtlePoint { get; set; }
        public Status Status { get; set; }
    }
}
