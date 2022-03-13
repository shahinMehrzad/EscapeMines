using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Models;
using Betsson_EscapeMines.Services.Services;
using Xunit;

namespace Betsson_EscapeMines.Xunit
{
    public class TurtleServiceTest
    {
        private readonly TurtleService _turtleService;

        public TurtleServiceTest()
        {
            _turtleService = new TurtleService();
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1 t")]
        [InlineData("1 -1")]
        [InlineData("5 1")]
        [InlineData("2 3 X")]
        public void TurtleService_CheckTurtulePoint_InvalidTurtlePoint_Failure(params string[] ExitPoint)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            Assert.Throws<InvalidTurtlePointException>(() => _turtleService.CheckTurtulePoint(boardSize, ExitPoint[0]));
        }
    }
}
