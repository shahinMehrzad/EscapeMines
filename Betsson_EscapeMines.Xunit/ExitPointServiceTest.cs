using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Models;
using Betsson_EscapeMines.Services.Services;
using Xunit;

namespace Betsson_EscapeMines.Xunit
{
    public class ExitPointServiceTest
    {
        private readonly ExitPointService _exitPointService;

        public ExitPointServiceTest()
        {
            _exitPointService = new ExitPointService();
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1 t")]
        [InlineData("1 -1")]
        [InlineData("5,1")]
        public void ExitPoint_CheckExitPoint_InvalidExitPoint_Failure(params string[] ExitPoint)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            Assert.Throws<InvalidExitPointException>(() => _exitPointService.CheckExitPoint(boardSize, ExitPoint[0]));
        }
    }
}
