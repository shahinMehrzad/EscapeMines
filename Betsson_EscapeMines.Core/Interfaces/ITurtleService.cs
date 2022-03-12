using Betsson_EscapeMines.Core.Models;
using System.Collections.Generic;

namespace Betsson_EscapeMines.Core.Interfaces
{
    public interface ITurtleService
    {
        TurtlePointModel CheckTurtulePoint(BoardSize boardSize, List<MinesPoints> minesPoints, ExitPoint exitPoint, string turtlePoint);
    }
}
