using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson_EscapeMines.Services.Services
{
    public class GameOprator : IGameOprator
    {
        private readonly BoardSizeService _boardSizeService;
        private readonly MinesPointsService _minesPointsService;
        private readonly ExitPointService _exitPointService;
        private readonly TurtleService _turtleService;
        private readonly MoveService _moveService;

        private string[] Commands { get; set; }

        public GameOprator()
        {            
            _boardSizeService = new BoardSizeService();
            _minesPointsService = new MinesPointsService();
            _exitPointService = new ExitPointService();
            _turtleService = new TurtleService();
            _moveService = new MoveService();

                        
        }

        public List<MatchMovementModel> InitializeGame()
        {
            //Get Board Size
            BoardSizeModel boardSizeResponse = _boardSizeService.CheckBoardSize(Commands[0]);
            //Get Mines Points
            MinesPointsModel minesPointsResponse = _minesPointsService.CheckMinesPoints(boardSizeResponse.BoardSize, Commands[1]);
            //Get Exit Point
            ExitPointModel exitPointModel = _exitPointService.CheckExitPoint(boardSizeResponse.BoardSize, Commands[2]);
            //Get Turtle Start Point
            TurtlePointModel turtlePointModel = _turtleService.CheckTurtulePoint(boardSizeResponse.BoardSize, Commands[3]);

            //Run Game
            string seriesOfMoves = null;
            for (int i = 4; i < Commands.Length; i++)
            {
                seriesOfMoves += $" {Commands[i]}";
            }
            return _moveService.CheckMovement(boardSizeResponse.BoardSize, minesPointsResponse.minesPoints, exitPointModel.ExitPoint, turtlePointModel.TurtlePoint, seriesOfMoves.Trim());
        }

        public List<MatchMovementModel> MatchMovement(string[] commandLines)
        {
            Commands = commandLines;
            return InitializeGame();
        }
    }
}
