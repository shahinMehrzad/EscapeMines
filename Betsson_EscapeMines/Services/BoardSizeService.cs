using Betsson_EscapeMines.EscapeMinesExceptions;
using Betsson_EscapeMines.Interfaces;
using Betsson_EscapeMines.Models;

namespace Betsson_EscapeMines.Services
{
    public class BoardSizeService : IBoardSizeService
    {
        public BoardSizeResponse CheckBoardSize(string boardSize)
        {
            if (string.IsNullOrEmpty(boardSize))
                throw new InvalidBoardSizeException("Please enter a valid board size. For example : 4 5");  
            
            var splitBoardSize = boardSize.Split(" ");

            if (splitBoardSize.Length != 2)
                throw new InvalidBoardSizeException("Please enter a valid board size. For example : 4 5");
            
            if (!int.TryParse(splitBoardSize[0], out int value) || !int.TryParse(splitBoardSize[1], out int value2))
                throw new InvalidBoardSizeException("Please enter a valid board size. For example : 4 5");

            int column = int.Parse(splitBoardSize[0]);
            int row = int.Parse(splitBoardSize[1]);

            if(column < 1 || row < 1)
                throw new InvalidBoardSizeException("Please enter a valid board size. Just enter numbers with one space. Column and row value should be more than zero.  For example : 4 5");

            return new BoardSizeResponse() { IsValid = true, boardSize = new BoardSize() { Columns = column, Rows = row } };
        }


    }
}
