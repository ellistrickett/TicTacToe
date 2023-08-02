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
        public void Game_IsValidMove_ShouldReturnFalseForRepeatedMove()
        {
            // Arrange
            int validMove = 2;

            // Set the board to simulate a move by player 'X' at (0,1)
            _game.Board[0, 1] = 'X';

            // Act
            bool isValid = _game.IsValidMove(validMove);

            // Assert
            Assert.False(isValid);
        }

    }
}