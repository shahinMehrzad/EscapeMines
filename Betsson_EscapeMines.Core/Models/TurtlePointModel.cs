using Betsson_EscapeMines.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson_EscapeMines.Core.Models
{
    public class TurtlePointModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public TurtlePoint TurtlePoint { get; set; }
    }

    public class TurtlePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}
