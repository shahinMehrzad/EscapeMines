using Betsson_EscapeMines.Core.Enums;
using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Betsson_EscapeMines.Services.Services
{
    public class MoveService : IMoveService
    {
        public List<MatchMovementModel> CheckMovement(BoardSize boardSize, List<MinesPoints> minesPoints, ExitPoint exitPoint, TurtlePoint turtlePoint, string moveValues)
        {
            List<MatchMovementModel> lstMatchMovements = new List<MatchMovementModel>();
            foreach (var move in moveValues.Split(' '))
            {
                _ = Enum.TryParse(move, out MoveCommand moveCommand);
                
                if (lstMatchMovements.Count > 0 && lstMatchMovements.LastOrDefault().Status != Status.StillInDanger)
                    break;

                switch (moveCommand)
                {
                    case MoveCommand.M:
                        try
                        {
                            turtlePoint = CheckMovementIsValid(boardSize, turtlePoint);
                            if (turtlePoint.X == exitPoint.X && turtlePoint.Y == exitPoint.Y)
                            {
                                lstMatchMovements.Add(new MatchMovementModel { Message = "Turtle finds the exit point.", TurtlePoint = new TurtlePoint() { Direction = turtlePoint.Direction, X = turtlePoint.X, Y = turtlePoint.Y }, Status = Status.Success });
                            }
                            else
                            {
                                foreach (var item in minesPoints)
                                {
                                    if (turtlePoint.X == item.X && turtlePoint.Y == item.Y)
                                    {
                                        lstMatchMovements.Add(new MatchMovementModel { Message = "Turtle hits mine. :(", TurtlePoint = turtlePoint, Status = Status.MineHit });
                                        break;
                                    }
                                }
                                if (lstMatchMovements.Count > 0 && lstMatchMovements.LastOrDefault().Status == Status.MineHit)
                                       break;
                                else
                                    lstMatchMovements.Add(new MatchMovementModel { Message = "Turtle is still in danger.", TurtlePoint = new TurtlePoint() { Direction = turtlePoint.Direction, X = turtlePoint.X, Y = turtlePoint.Y }, Status = Status.StillInDanger });

                            }
                        }
                        catch (Exception e)
                        {
                            lstMatchMovements.Add(new MatchMovementModel { Message = e.Message, TurtlePoint = turtlePoint });
                        }
                        break;
                    case MoveCommand.R:
                        if (turtlePoint.Direction == Direction.N)
                            turtlePoint.Direction = Direction.E;
                        else if (turtlePoint.Direction == Direction.E)
                            turtlePoint.Direction = Direction.S;
                        else if (turtlePoint.Direction == Direction.S)
                            turtlePoint.Direction = Direction.W;
                        else if (turtlePoint.Direction == Direction.W)
                            turtlePoint.Direction = Direction.N;

                        lstMatchMovements.Add(new MatchMovementModel { Message = "The turtle has rotated to the right.", TurtlePoint = new TurtlePoint() { Direction = turtlePoint.Direction, X = turtlePoint.X, Y = turtlePoint.Y } });
                        break;
                    case MoveCommand.L:
                        if (turtlePoint.Direction == Direction.N)
                            turtlePoint.Direction = Direction.W;
                        else if (turtlePoint.Direction == Direction.E)
                            turtlePoint.Direction = Direction.N;
                        else if (turtlePoint.Direction == Direction.S)
                            turtlePoint.Direction = Direction.E;
                        else if (turtlePoint.Direction == Direction.W)
                            turtlePoint.Direction = Direction.S;

                        lstMatchMovements.Add(new MatchMovementModel { Message = "The turtle has rotated to the left.", TurtlePoint = new TurtlePoint() { Direction = turtlePoint.Direction, X = turtlePoint.X, Y = turtlePoint.Y } });
                        break;
                    default:
                        throw new InvalidMoveCommandException("Invalid move command.");
                }
            }
            return lstMatchMovements;
        }

        private TurtlePoint CheckMovementIsValid(BoardSize boardSize, TurtlePoint turtlePoint)
        {
            switch (turtlePoint.Direction)
            {
                case Direction.N:
                    if (turtlePoint.Y > 1)
                        turtlePoint.Y -= 1;
                    else
                        throw new InvalidMoveCommandException("The movement is not accessible.");
                    break;
                case Direction.S:
                    if (turtlePoint.Y < boardSize.Rows)
                        turtlePoint.Y += 1;
                    else
                        throw new InvalidMoveCommandException("The movement is not accessible.");
                    break;
                case Direction.E:
                    if (turtlePoint.X < boardSize.Columns)
                        turtlePoint.X += 1;
                    else
                        throw new InvalidMoveCommandException("The movement is not accessible.");
                    break;
                case Direction.W:
                    if (turtlePoint.X > 1)
                        turtlePoint.X -= 1;
                    else
                        throw new InvalidMoveCommandException("The movement is not accessible.");
                    break;
            }
            return turtlePoint;
        }
    }
}
