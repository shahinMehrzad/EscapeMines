using Betsson_EscapeMines.Core.EscapeMinesExceptions;
using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Betsson_EscapeMines.Services.Services
{
    public class MinesPointsService : IMinesPointsService
    {
        public MinesPointsModel CheckMinesPoints(string minesPoints, BoardSize boardSize)
        {
            if (string.IsNullOrEmpty(minesPoints))
                throw new InvalidMinesPointsException("At least one mine should be on the board.");

            if (!minesPoints.Contains(","))
                throw new InvalidMinesPointsException("The mines points should be separated by commas.");

            var splitlst = minesPoints.Split(" ");
            List<MinesPoints> lstMinesPoints = new List<MinesPoints>();

            foreach (var item in splitlst)
            {
                var splitMinesPoints = item.Split(",");
                if (!int.TryParse(splitMinesPoints[0], out int value) || !int.TryParse(splitMinesPoints[1], out int value2))
                    throw new InvalidMinesPointsException("This value is invalid. There are only numbers that are acceptable, and the maximum is 2,147,483,647.");

                else
                {
                    var x = int.Parse(splitMinesPoints[0]);
                    var y = int.Parse(splitMinesPoints[1]);
                    if (x > boardSize.Columns || y > boardSize.Rows || x < 1 || y < 1)
                        throw new InvalidMinesPointsException($"The point is not within the board size. The maximum acceptable column and row sizes are {boardSize.Columns} and {boardSize.Rows}, respectively.");

                    MinesPoints minesPointsModel = new MinesPoints() { X = x, Y = y };
                    if (!lstMinesPoints.Where(model=>model.X == minesPointsModel.X && model.Y == minesPointsModel.Y).Any())
                        lstMinesPoints.Add(minesPointsModel);
                }
            }

            if ((lstMinesPoints.Count + 2) >= (boardSize.Columns * boardSize.Rows))
                throw new InvalidMinesPointsException($"There can be a maximum of {(boardSize.Columns * boardSize.Rows) - 2} mines on this board. There are {lstMinesPoints.Count} points on this board.");

            return new MinesPointsModel() { IsValid = true, minesPoints = lstMinesPoints };
        }

        
    }
}
