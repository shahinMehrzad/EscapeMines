namespace Betsson_EscapeMines.Models
{
    public class BoardSize
    {
        public int Rows { get; set; }
        public int Columns { get; set; }        
    }

    public class BoardSizeResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public BoardSize boardSize { get; set; }
    }
}
