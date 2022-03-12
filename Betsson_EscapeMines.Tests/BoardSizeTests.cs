using Microsoft.VisualStudio.TestTools.UnitTesting;
using Betsson_EscapeMines.Helpers;

namespace Betsson_EscapeMines.Tests
{
    [TestClass]
    public class BoardSizeTests
    {
        [TestMethod]
        public void CheckBoardValues()
        {
            //Arrange
            string boardSize = null;            
            string boardSize2 = "23,1 12";            
            string boardSize3 = "-1 0";            
            string boardSize4 = "t 5";            
            string boardSize5 = "2147483647 2147483647";            
            BoardSizeHelper boardSizeHelper = new BoardSizeHelper();

            // Act
            var res = boardSizeHelper.CheckBoardSize(boardSize).IsValid;
            var res2 = boardSizeHelper.CheckBoardSize(boardSize2).IsValid;
            var res3 = boardSizeHelper.CheckBoardSize(boardSize3).IsValid;
            var res4 = boardSizeHelper.CheckBoardSize(boardSize4).IsValid;
            var res5 = boardSizeHelper.CheckBoardSize(boardSize5).IsValid;
            
            // Assert                      
            Assert.IsFalse(res, "The board size has not been entered correctly."); 
            Assert.IsFalse(res2, "The board size has not been entered correctly."); 
            Assert.IsFalse(res3, "The board size has not been entered correctly."); 
            Assert.IsFalse(res4, "The board size has not been entered correctly."); 
            Assert.IsFalse(res5, "The board size has not been entered correctly."); 
        }        
    }
}
