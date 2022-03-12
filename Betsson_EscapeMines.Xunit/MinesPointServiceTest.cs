namespace Betsson_EscapeMines.Xunit
{
    public class MinesPointServiceTest
    {
        
        
        //[Fact]
        //public void MinesPoints_ShouldReturnThrows_OnNullInput()
        //{
        //    //Arrange
        //    var mock = new Mock<IMinesPointsService>();
        //    string value = null;
        //    BoardSize boardSize = new BoardSize() { Columns = 4, Rows =5 };

        //    // Act
        //    var boardSizeResponse = _minesPointsService.CheckMinesPoints(value, boardSize);
        //    //Setup(x => x.CheckMinesPoints(value, boardSize)).Throws<InvalidMinesPointsException>();

        //    //Assert
        //    mock.Setup(x=> x.CheckMinesPoints(value,boardSize).)
        //    Assert.Throws<InvalidMinesPointsException>(() => _minesPointsService.CheckMinesPoints(value, boardSize));
        //        //Throws<InvalidMinesPointsException>(() => _minesPointsService.Object.CheckMinesPoints(value, boardSize));
        //}

        //[Fact]
        //public void MinesPoints_ShouldReturnThrows_OnValueWithoutComma()
        //{
        //    //Arrange
        //    string value = "4 5";
        //    BoardSize boardSize = new BoardSize() { Columns = 4, Rows = 5 };
        //    _minesPointsService.Setup(x => x.CheckMinesPoints(value, boardSize)).Throws<InvalidMinesPointsException>();
        //    // Act

        //    //Assert
        //    Assert.Throws<InvalidMinesPointsException>(() => _minesPointsService.Object.CheckMinesPoints(value, boardSize));
        //}

        //[Fact]
        //public void MinesPoints_ShouldReturnThrows_OnValueNotBeInteger()
        //{
        //    //Arrange
        //    string value = "4,t";
        //    BoardSize boardSize = new BoardSize() { Columns = 4, Rows = 5 };
        //    _minesPointsService.Setup(x => x.CheckMinesPoints(value, boardSize)).Throws<InvalidMinesPointsException>();
        //    // Act

        //    //Assert
        //    Assert.Throws<InvalidMinesPointsException>(() => _minesPointsService.Object.CheckMinesPoints(value, boardSize));
        //}

        //[Fact]
        //public void MinesPoints_ShouldReturnThrows_OnValueIsBiggerThanBoardSize()
        //{
        //    //Arrange
        //    string value = "1,1";
        //    BoardSize boardSize = new BoardSize() { Columns = 4, Rows = 5 };
        //    _minesPointsService.Setup(x => x.CheckMinesPoints(value, boardSize)).Throws<InvalidMinesPointsException>();
        //    // Act

        //    //Assert
        //    Assert.Throws<InvalidMinesPointsException>(() => _minesPointsService.Object.CheckMinesPoints(value, boardSize));
        //}
    }
}
