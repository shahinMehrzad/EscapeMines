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

        private string[] Commands { get; set; }

        public GameOprator(string[] commandLines)
        {
            Commands = commandLines;
            _boardSizeService = new BoardSizeService();
            _minesPointsService = new MinesPointsService();
            _exitPointService = new ExitPointService();
            _turtleService = new TurtleService();

            Run();
        }

        public void Run()
        {
            //Get Board Size
            BoardSizeModel boardSizeResponse = _boardSizeService.CheckBoardSize(Commands[0]);
            //Get Mines Points
            MinesPointsModel minesPointsResponse = _minesPointsService.CheckMinesPoints(boardSizeResponse.BoardSize, Commands[1]);
            //Get Exit Point
            ExitPointModel exitPointModel = _exitPointService.CheckExitPoint(boardSizeResponse.BoardSize, Commands[2]);
            //Get Turtle Start Point
            TurtlePointModel turtlePointModel = _turtleService.CheckTurtulePoint(boardSizeResponse.BoardSize, Commands[3]);
        }
    }
}
