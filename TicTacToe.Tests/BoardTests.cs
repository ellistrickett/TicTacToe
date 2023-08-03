using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        private readonly IBoard _board;

        public BoardTests()
        {
            _board = new Board();
        }

        [Fact]
        public void Board_InitializesWithCorrectValues()
        {
            // Act
            char[,] result = _board.GetBoard();

            // Assert
            Assert.Equal(new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            }, result);
        }

        [Fact]
        public void Board_SetCell_ShouldUpdateCellWithSymbol()
        {
            // Act
            _board.SetCell(0, 0, 'X');
            _board.SetCell(1, 1, 'O');

            // Assert
            char[,] result = _board.GetBoard();
            Assert.Equal(new char[,]
            {
                { 'X', '-', '-' },
                { '-', 'O', '-' },
                { '-', '-', '-' }
            }, result);
        }

        [Fact]
        public void Board_GetCell_ShouldReturnCorrectValue()
        {
            // Arrange
            char[,] newBoard = new char[,]
            {
                    { 'X', '-', '-' },
                    { '-', '-', '-' },
                    { '-', '-', '-' }
            };

            // Act
            _board.SetBoard(newBoard);
            char cell = _board.GetCell(0, 0);

            // Assert
            Assert.Equal('X', cell);
        }
    }
}