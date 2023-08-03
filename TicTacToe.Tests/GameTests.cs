using Moq;
using System.Security.Cryptography;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        private readonly IGame _game;

        public GameTests()
        {
            _game = new Game();
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

            Assert.Equal(expectedBoard, _game.GetBoard());
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnTrueForValidMove()
        {
            // Arrange
            int validMove = 3;

            // Act
            bool isValid = _game.IsValidMove(validMove);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnFalseForOccupiedCell()
        {
            // Arrange
            int move = 2;

            _game.Board[0, 1] = 'X';

            // Act
            bool isValid = _game.IsValidMove(move);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void Game_MakeMove_ShouldUpdateTheBoard()
        {
            // Arrange
            int validMove = 1;

            // Act
            _game.MakeMove(validMove, 'X');

            // Assert
            Assert.Equal('X', _game.Board[0, 0]);
        }

        [Fact]
        public void Game_IsGameOver_ShouldReturnFalse()
        {
            // Act
            bool isGameOver = _game.IsGameOver();

            // Assert
            Assert.False(isGameOver);
        }

        [Fact]
        public void Game_MakeComputerMove_ShouldSelectValidUnoccupiedCell()
        {
            // Act
            _game.MakeComputerMove('O');

            // Assert
            Assert.True(_game.IsValidMove(4));
            Assert.Equal('O', _game.Board[1, 0]);
        }

    }
}