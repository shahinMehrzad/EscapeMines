using Betsson_EscapeMines.Core.Models;

namespace Betsson_EscapeMines.Core.Interfaces
{
    public interface IMinesPointsService
    {
        MinesPointsModel CheckMinesPoints(BoardSize boardSize, string minesPoints);
    }
}
