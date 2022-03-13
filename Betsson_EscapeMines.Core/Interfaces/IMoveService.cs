using Betsson_EscapeMines.Core.Models;
using System.Collections.Generic;

namespace Betsson_EscapeMines.Core.Interfaces
{
    public interface IMoveService
    {
        List<MatchMovementModel> CheckMovement(BoardSize boardSize, List<MinesPoints> minesPoints, ExitPoint exitPoint, TurtlePoint turtlePoint, string moveValues);
    }
}
