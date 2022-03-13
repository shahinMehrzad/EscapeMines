using Betsson_EscapeMines.Core.Exceptions;
using Betsson_EscapeMines.Core.Models;
using Betsson_EscapeMines.Services.Services;
using Xunit;

namespace Betsson_EscapeMines.Xunit
{
    public class MinesPointServiceTest
    {

        private readonly MinesPointsService _minesPointsService;

        public MinesPointServiceTest()
        {
            _minesPointsService = new MinesPointsService();
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1,t")]
        [InlineData("1,1 2,6")]
        [InlineData("1,1 1,-2 3,1")]
        public void MinePoints_CheckMinesPoints_InvalidminesPoints_Failure(params string[] minesPoints)
        {
            var boardSize = new BoardSize() { Columns = 5, Rows = 4 };
            Assert.Throws<InvalidMinesPointsException>(() => _minesPointsService.CheckMinesPoints(boardSize, minesPoints[0]));
        }        
    }
}
