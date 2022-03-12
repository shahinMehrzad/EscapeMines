using Betsson_EscapeMines.EscapeMinesExceptions;
using Betsson_EscapeMines.Interfaces;
using Moq;
using System;
using Xunit;

namespace Betsson_EscapeMines.Xunit
{
    public class BoardSizeServiceTest
    {
        private  Mock<IBoardSizeService> _boardService;
        public BoardSizeServiceTest()
        {
            _boardService = new Mock<IBoardSizeService>();
        }

        [Fact]
        public void CheckBoardSize_ShouldReturnThrows_OnNullInput()
        {
            //Arrange
            string value = null;
            _boardService.Setup(x => x.CheckBoardSize(value)).Throws<InvalidBoardSizeException>();
            // Act
            //var result = _boardService.Object.CheckBoardSize(value);
            //Assert
            Assert.Throws<InvalidBoardSizeException>(()=>_boardService.Object.CheckBoardSize(value));
        }

        [Fact]
        public void CheckBoardSize_ShouldReturnThrows_OnValueWithoutSpaceInput()
        {
            //Arrange
            string value = "21-5";
            _boardService.Setup(x => x.CheckBoardSize(value)).Throws<InvalidBoardSizeException>();
            // Act
            
            //Assert
            Assert.Throws<InvalidBoardSizeException>(() => _boardService.Object.CheckBoardSize(value));
        }

        [Fact]
        public void CheckBoardSize_ShouldReturnThrows_OnValueNotbeIntegerInput()
        {
            //Arrange
            string value = "4 t";
            _boardService.Setup(x => x.CheckBoardSize(value)).Throws<InvalidBoardSizeException>();
            // Act
            
            //Assert
            Assert.Throws<InvalidBoardSizeException>(() => _boardService.Object.CheckBoardSize(value));
        }

        [Fact]
        public void CheckBoardSize_ShouldReturnThrows_OnValuesNotPosotiveInput()
        {
            //Arrange
            string value = "-5 -3";
            _boardService.Setup(x => x.CheckBoardSize(value)).Throws<InvalidBoardSizeException>();
            // Act

            //Assert
            Assert.Throws<InvalidBoardSizeException>(() => _boardService.Object.CheckBoardSize(value));
        }

        [Fact]
        public void CheckBoardSize_ShouldReturnTrue_OnValuesAreAccaptable()
        {
            //Arrange
            string value = "5 3";
            var expectedResult = new Models.BoardSizeModel() { IsValid = true };
            _boardService.Setup(x => x.CheckBoardSize(value)).Returns(expectedResult);
            //Act
            var result = _boardService.Object.CheckBoardSize(value);
            //Assert
            Assert.True(result.IsValid);
        }
    }
}
