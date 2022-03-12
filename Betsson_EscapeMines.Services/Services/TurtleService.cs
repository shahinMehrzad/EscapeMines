using Betsson_EscapeMines.Core.Enums;
using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;
using System;
using System.Collections.Generic;

namespace Betsson_EscapeMines.Services.Services
{
    public class TurtleService : ITurtleService
    {
        public TurtlePointModel CheckTurtulePoint(BoardSize boardSize, string turtlePoint)
        {
            if (string.IsNullOrEmpty(turtlePoint))
                throw new InvalidTurtlePointException("The turtle point cannot be null or empty.");

            var splitTurtlePoint = turtlePoint.Split(" ");

            if (splitTurtlePoint.Length != 3)
                throw new InvalidTurtlePointException("The turtle point should be separated by space characters.");

            if (!int.TryParse(splitTurtlePoint[0], out int value) || !int.TryParse(splitTurtlePoint[1], out int value2))
                throw new InvalidTurtlePointException("This value is invalid.");
            
            int x = int.Parse(splitTurtlePoint[0]) + 1;
            int y = int.Parse(splitTurtlePoint[1]) + 1;

            if (x < 1 || y < 1)
                throw new InvalidBoardSizeException("This value is invalid. Numbers should be entered with one space between them. X and Y values should be greater than zero.");

            if (x > boardSize.Columns || y > boardSize.Rows)
                throw new InvalidExitPointException($"This value is invalid. The turtle point maximum values is {boardSize.Columns} for column and {boardSize.Rows} for row.");

            Direction direction = new Direction();
            if (Enum.IsDefined(typeof(Direction), splitTurtlePoint[2]))
                _ = Enum.TryParse(splitTurtlePoint[2], out direction);
            else
                throw new InvalidTurtlePointException("The turtle start point direction is incorrect.");

            return new TurtlePointModel() { IsValid = true, TurtlePoint = new TurtlePoint() { X = x, Y = y, Direction = direction } };
        }
    }
}
