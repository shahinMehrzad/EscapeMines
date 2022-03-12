namespace Betsson_EscapeMines.Core.Models
{
    public class ExitPointModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public ExitPoint ExitPoint { get; set; }
    }

    public class ExitPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
