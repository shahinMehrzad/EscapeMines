using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;
using System.Collections.Generic;

namespace Betsson_EscapeMines.Services.Services
{
    public class ExitPointService : IExitPointService
    {
        public ExitPointModel CheckExitPoint(BoardSize boardSize, string ExitPoint)
        {
            if (string.IsNullOrEmpty(ExitPoint))
                throw new InvalidExitPointException("The exit point cannot be null or empty.");

            var splitExitPoint = ExitPoint.Split(" ");

            if (splitExitPoint.Length != 2)
                throw new InvalidExitPointException("The exit point should be separated by a space character.");

            if (!int.TryParse(splitExitPoint[0], out int value) || !int.TryParse(splitExitPoint[1], out int value2))
                throw new InvalidExitPointException($"This value is invalid. There are only numbers that are acceptable, and the maximum is {boardSize.Columns} for column and {boardSize.Rows} for row.");

            int x = int.Parse(splitExitPoint[0]) + 1;
            int y = int.Parse(splitExitPoint[1]) + 1;

            if (x < 1 || y < 1)
                throw new InvalidExitPointException("This value is invalid. The exit point values should be greater than zero.");

            if (x > boardSize.Columns || y > boardSize.Rows)
                throw new InvalidExitPointException($"This value is invalid. The exit point maximum values is {boardSize.Columns} for column and {boardSize.Rows} for row.");

            return new ExitPointModel() { IsValid = true, ExitPoint = new ExitPoint { X = x, Y = y } };
        }
    }
}
