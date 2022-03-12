using Betsson_EscapeMines.Models;

namespace Betsson_EscapeMines.Interfaces
{
    public interface IBoardSizeService
    {
        BoardSizeResponse CheckBoardSize(string boardSize);
    }
}
