using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson_EscapeMines.Models
{
    public class MinesPoints
    {
        public Point Point { get; set; }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class MinesPointsResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public List<MinesPoints> minesPoints { get; set; }
    }
}
