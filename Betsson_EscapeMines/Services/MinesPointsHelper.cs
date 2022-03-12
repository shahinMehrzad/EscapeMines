using Betsson_EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson_EscapeMines.Helpers
{
    public class MinesPointsHelper
    {
        public MinesPointsResponse CheckMinesPoints(string minesPoints, BoardSize boardSize)
        {
            if (string.IsNullOrEmpty(minesPoints))
            {
                return new MinesPointsResponse()
                {
                    Message = "Please enter valid list of mines points(For example = 1,1 3,1 3,3).",
                };
            }
            if (!minesPoints.Contains(","))
            {
                return new MinesPointsResponse()
                {
                    Message = "Please enter valid list of mines points(For example = 1,1 3,1 3,3)."
                };
            }
            var splitlst = minesPoints.Split(" ");
            List<MinesPoints> lstMinesPoints = new List<MinesPoints>();

            foreach(var item in splitlst)
            {
                var splitMinesPoints = item.Split(",");
                if (!int.TryParse(splitMinesPoints[0], out int value) || !int.TryParse(splitMinesPoints[1], out int value2))
                {
                    return new MinesPointsResponse()
                    {
                        Message = "Please enter valid list of mines points. Just enter numbers with comma seprator. You can add more points with a space between your points. For example = 1,1 3,1 3,3"
                    };
                }
                else
                {
                    var x = int.Parse(splitMinesPoints[0]);
                    var y = int.Parse(splitMinesPoints[1]);
                    if (x > boardSize.Columns || y > boardSize.Rows || x < 1 || y < 1)
                    {
                        return new MinesPointsResponse()
                        {
                            Message = $"The point is out of board size. Please enter max column point {boardSize.Columns} and max row point {boardSize.Rows}."
                        };
                    }
                    Point point = new Point() { X = x, Y = y };
                    MinesPoints minesPointsModel = new MinesPoints();
                    minesPointsModel.Point = point;
                    lstMinesPoints.Add(minesPointsModel);
                }
            }

            if(lstMinesPoints.Count > (boardSize.Columns * boardSize.Rows))
            {
                return new MinesPointsResponse()
                {
                    Message = $"Max mines in this board is {(boardSize.Columns * boardSize.Rows)}. You selected {lstMinesPoints.Count} points in this board."
                };
            }

            return new MinesPointsResponse() { IsValid = true, minesPoints =  lstMinesPoints } ;
        }
    }
}
