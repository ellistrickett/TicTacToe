using Moq;
using System.Security.Cryptography;

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
        public void Game_ShouldInitializeBoardCorrectly()
        {

            // Assert
            char[,] expectedBoard = new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };

            Assert.Equal(expectedBoard, _fixture.Game.GetBoard());
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnTrueForValidMove()
        {
            // Arrange
            int validMove = 3;

            // Act
            bool isValid = _fixture.Game.IsValidMove(validMove);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnFalseForOccupiedCell()
        {
            // Arrange
            int move = 2;

            _fixture.Game.Board[0, 1] = 'X';

            // Act
            bool isValid = _fixture.Game.IsValidMove(move);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void Game_MakeMove_ShouldUpdateTheBoard()
        {
            // Arrange
            int validMove = 1;

            // Act
            _fixture.Game.MakeMove(validMove, 'X');

            // Assert
            Assert.Equal('X', _fixture.Game.Board[0, 0]);
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
        public void Game_MakeComputerMove_ShouldSelectValidUnoccupiedCell()
        {
            //Arrange
            int randomMove = 4;
            _fixture.MockRandomNumberGenerator.Setup(r => r.Next())
                        .Returns(randomMove);

            // Act
            _fixture.Game.MakeComputerMove('O');

            // Assert
            Assert.Equal('O', _fixture.Game.Board[1, 0]);
        }

    }
}