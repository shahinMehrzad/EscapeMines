using Betsson_EscapeMines.Core.Models;

namespace Betsson_EscapeMines.Core.Interfaces
{
    public interface IBoardSizeService
    {
        BoardSizeModel CheckBoardSize(string boardSize);
    }
}
