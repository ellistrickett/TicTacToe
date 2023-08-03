using Moq;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        private readonly GameFixture _fixture;

        public GameTests()
        {
            _fixture = new GameFixture();
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnTrueForValidMove()
        {
            // Arrange
            int row = 0;
            int col = 0;

            _fixture.MockBoard.Setup(m => m.GetCell(row, col))
                    .Returns('-');

            // Act
            bool isValid = _fixture.Game.IsValidMove(row, col);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnFalseForOccupiedCell()
        {
            // Arrange
            int row = 0;
            int col = 1;

            _fixture.MockBoard.Setup(m => m.GetCell(row, col))
                    .Returns('O');

            // Act
            bool isValid = _fixture.Game.IsValidMove(row, col);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void Game_IsGameOver_ShouldReturnFalse()
        {
            // Act
            bool isGameOver = _fixture.Game.IsGameOver();

            // Assert
            Assert.False(isGameOver);
        }

        [Fact]
        public void Game_IsGameOver_BoardFull_ShouldReturnTrue_GameResultDraw()
        {
            //Arrange
            char[,] fullBoard = new char[,]
            {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'O', 'X', 'O' }
            };

            _fixture.MockBoard.Setup(m => m.GetBoard())
                        .Returns(fullBoard);

            // Act
            bool isGameOver = _fixture.Game.IsGameOver();

            // Assert
            Assert.True(isGameOver);
            Assert.Equal("Draw", _fixture.Game.GameResult);
        }

        [Fact]
        public void Game_IsGameOver_LessThan5Moves_ShouldReturnFalse()
        {
            //Arrange
            char[,] lessThan5MovesBoard = new char[,]
            {
                { 'X', '-', '-' },
                { '-', 'O', 'O' },
                { '-', '-', 'X' }
            };

            _fixture.MockBoard.Setup(m => m.GetBoard())
                        .Returns(lessThan5MovesBoard);

            // Act
            bool isGameOver = _fixture.Game.IsGameOver();

            // Assert
            Assert.False(isGameOver);
        }

        [Fact]
        public void Game_IsGameOver_ShouldReturnTrueForXWinRow_GameResultX()
        {
            char[,] board = new char[,]
            {
                { 'X', 'X', 'X' },
                { 'O', 'O', '-' },
                { '-', '-', '-' }
            };

            // Act
            _fixture.MockBoard.Setup(m => m.GetBoard())
                        .Returns(board);
            bool isGameOver = _fixture.Game.IsGameOver();

            // Assert
            Assert.True(isGameOver);
            Assert.Equal("X", _fixture.Game.GameResult);
        }

        [Fact]
        public void Game_IsGameOver_ShouldReturnTrueForXWinColumn_GameResultX()
        {
            char[,] board = new char[,]
            {
                { 'X', 'O', '-' },
                { 'X', 'O', '-' },
                { 'X', '-', '-' }
            };

            // Act
            _fixture.MockBoard.Setup(m => m.GetBoard())
                        .Returns(board);
            bool isGameOver = _fixture.Game.IsGameOver();

            // Assert
            Assert.True(isGameOver);
            Assert.Equal("X", _fixture.Game.GameResult);
        }

        [Fact]
        public void Game_IsGameOver_ShouldReturnTrueForXWinDiagonal_GameResultX()
        {
            char[,] board = new char[,]
            {
                { 'X', 'O', '-' },
                { '-', 'X', '-' },
                { 'O', '-', 'X' }
            };

            // Act
            _fixture.MockBoard.Setup(m => m.GetBoard())
                        .Returns(board);
            bool isGameOver = _fixture.Game.IsGameOver();

            // Assert
            Assert.True(isGameOver);
            Assert.Equal("X", _fixture.Game.GameResult);
        }

        [Fact]
        public void Game_MakeComputerMove_ShouldSelectValidUnoccupiedCell()
        {
            //Arrange
            int randomMove = 4;
            _fixture.MockRandomNumberGenerator.Setup(r => r.Next())
                        .Returns(randomMove);

            _fixture.MockBoard.Setup(m => m.GetCell(1, 0))
                        .Returns('-');

            // Act
            _fixture.Game.MakeComputerMove('O');

            // Assert
            _fixture.MockRandomNumberGenerator.Verify(m => m.Next(), Times.Once);
            _fixture.MockBoard.Verify(m => m.GetCell(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Game_MakeComputerMove_ShouldKeepGeneratingRandomNumbersUntilValidMove()
        {
            _fixture.MockRandomNumberGenerator.SetupSequence(r => r.Next())
                        .Returns(4)
                        .Returns(5)
                        .Returns(6)
                        .Returns(7);

            _fixture.MockBoard.SetupSequence(m => m.GetCell(It.IsAny<int>(), It.IsAny<int>()))
                        .Returns('O')
                        .Returns('X')
                        .Returns('X')
                        .Returns('-');

            // Act
            _fixture.Game.MakeComputerMove('O');

            // Assert
            _fixture.MockRandomNumberGenerator.Verify(m => m.Next(), Times.Exactly(4));
            _fixture.MockBoard.Verify(m => m.GetCell(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(4));
        }

    }
}