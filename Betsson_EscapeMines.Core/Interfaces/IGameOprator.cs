using Betsson_EscapeMines.Core.Models;
using System.Collections.Generic;

namespace Betsson_EscapeMines.Core.Interfaces
{
    public interface IGameOprator
    {
        List<MatchMovementModel> MatchMovement(string[] commandLines);
    }
}
