using System.Collections.Generic;

namespace Betsson_EscapeMines.Core.Models
{
    public class MinesPointsModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public List<MinesPoints> minesPoints { get; set; }        
    }
        
    public class MinesPoints
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
