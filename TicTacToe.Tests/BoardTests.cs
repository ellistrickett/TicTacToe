using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_InitializesWithCorrectValues()
        {
            // Arrange
            IBoard board = new Board();

            // Act
            char[,] result = board.GetBoard();

            // Assert
            Assert.Equal('-', result[0, 0]);
            Assert.Equal('-', result[0, 1]);
            Assert.Equal('-', result[0, 2]);
            Assert.Equal('-', result[1, 0]);
            Assert.Equal('-', result[1, 1]);
            Assert.Equal('-', result[1, 2]);
            Assert.Equal('-', result[2, 0]);
            Assert.Equal('-', result[2, 1]);
            Assert.Equal('-', result[2, 2]);
        }

        [Fact]
        public void Board_SetCell_ShouldUpdateCellWithSymbol()
        {
            // Arrange
            IBoard board = new Board();

            // Act
            board.SetCell(0, 0, 'X');
            board.SetCell(1, 1, 'O');

            // Assert
            char[,] result = board.GetBoard();
            Assert.Equal('X', result[0, 0]);
            Assert.Equal('O', result[1, 1]);
        }
    }
}