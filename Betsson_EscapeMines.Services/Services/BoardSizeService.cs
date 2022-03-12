using Betsson_EscapeMines.Core.EscapeMinesExceptions;
using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;

namespace Betsson_EscapeMines.Services.Services
{
    public class BoardSizeService : IBoardSizeService
    {
        public BoardSizeModel CheckBoardSize(string boardSize)
        {
            if (string.IsNullOrEmpty(boardSize))
                throw new InvalidBoardSizeException("The board size cannot be empty.");  
            
            var splitBoardSize = boardSize.Split(" ");

            if (splitBoardSize.Length != 2)
                throw new InvalidBoardSizeException("The board size should be separated by a space character.");
            
            if (!int.TryParse(splitBoardSize[0], out int value) || !int.TryParse(splitBoardSize[1], out int value2))
                throw new InvalidBoardSizeException("This value is invalid. There are only numbers that are acceptable, and the maximum is 2,147,483,647.");

            int column = int.Parse(splitBoardSize[0]);
            int row = int.Parse(splitBoardSize[1]);

            if(column < 1 || row < 1)
                throw new InvalidBoardSizeException("This value is invalid. Numbers should be entered with one space between them. Column and row values should be greater than zero.");

            return new BoardSizeModel() { IsValid = true, BoardSize = new BoardSize() { Columns = column, Rows = row } };
        }


    }
}
