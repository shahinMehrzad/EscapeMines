using Betsson_EscapeMines.Core.Enums;
using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Models;
using Betsson_EscapeMines.Services.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Betsson_EscapeMines.Xunit
{
    public class MoveServiceTest
    {
        private readonly MoveService _moveService;

        public MoveServiceTest()
        {
            _moveService = new MoveService();
        }

        [Theory]
        [InlineData("")]        
        public void MoveService_CheckMovement_InvalidMovement_Failure(params string[] moveCommands)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            var minePoints = new List<MinesPoints>() { new MinesPoints() { X = 1, Y = 1 }, new MinesPoints() { X = 3, Y = 1 }, new MinesPoints() { X = 3, Y = 3 } };
            var exitPoint = new ExitPoint() { X = 4, Y = 2 };
            var turtlePoint = new TurtlePoint() { X = 0, Y = 1, Direction = Core.Enums.Direction.N };
            Assert.Throws<InvalidMoveCommandException>(() => _moveService.CheckMovement(boardSize, minePoints, exitPoint, turtlePoint,moveCommands[0]));
        }

        [Theory]
        [InlineData("R M")]
        [InlineData("M R M R M")]
        [InlineData("L L M L M M M R M")]
        [InlineData("L L M L M M M L M")]        
        public void MoveService_CheckMovement_MineHit_Succeed(params string[] moveCommands)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            var minePoints = new List<MinesPoints>() { new MinesPoints() { X = 2, Y = 2 }, new MinesPoints() { X = 4, Y = 2 }, new MinesPoints() { X = 4, Y = 4 } };
            var exitPoint = new ExitPoint() { X = 5, Y = 3 };
            var turtlePoint = new TurtlePoint() { X = 1, Y = 2, Direction = Core.Enums.Direction.N };
            var result = _moveService.CheckMovement(boardSize, minePoints, exitPoint, turtlePoint, moveCommands[0]);
            Assert.Equal(Status.MineHit, result.LastOrDefault().Status);
        }

        [Theory]
        [InlineData("L L M L M M M M")]
        [InlineData("L L M L M M L M M R M M R M M")]
        public void MoveService_CheckMovement_ExitPoint_Succeed(params string[] moveCommands)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            var minePoints = new List<MinesPoints>() { new MinesPoints() { X = 2, Y = 2 }, new MinesPoints() { X = 4, Y = 2 }, new MinesPoints() { X = 4, Y = 4 } };
            var exitPoint = new ExitPoint() { X = 5, Y = 3 };
            var turtlePoint = new TurtlePoint() { X = 1, Y = 2, Direction = Core.Enums.Direction.N };
            var result = _moveService.CheckMovement(boardSize, minePoints, exitPoint, turtlePoint, moveCommands[0]);
            Assert.Equal(Status.Success, result.LastOrDefault().Status);
        }

        [Theory]
        [InlineData("M R M M M M R M")]
        [InlineData("L L M M L M L M R M")]
        public void MoveService_CheckMovement_StillInDanger_Succeed(params string[] moveCommands)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            var minePoints = new List<MinesPoints>() { new MinesPoints() { X = 2, Y = 2 }, new MinesPoints() { X = 4, Y = 2 }, new MinesPoints() { X = 4, Y = 4 } };
            var exitPoint = new ExitPoint() { X = 5, Y = 3 };
            var turtlePoint = new TurtlePoint() { X = 1, Y = 2, Direction = Core.Enums.Direction.N };
            var result = _moveService.CheckMovement(boardSize, minePoints, exitPoint, turtlePoint, moveCommands[0]);
            Assert.Equal(Status.StillInDanger, result.LastOrDefault().Status);
        }
    }
}
