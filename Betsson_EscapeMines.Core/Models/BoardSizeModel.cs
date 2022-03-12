namespace Betsson_EscapeMines.Core.Models
{
    public class BoardSizeModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public BoardSize BoardSize { get; set; }
              
    }

    public class BoardSize
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
