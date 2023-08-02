namespace TicTacToe.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_ShouldInitializeBoardCorrectly()
        {
            // Arrange
            var game = new Game();

            // Act

            // Assert
            char[,] expectedBoard = new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };

            Assert.Equal(expectedBoard, game.GetBoard());
        }

        [Fact]
        public void Game_IsValidMove_ShouldReturnTrueForValidMove()
        {
            // Arrange
            Game game = new Game();
            int validMove = 3;

            // Act
            bool isValid = game.IsValidMove(validMove);

            // Assert
            Assert.True(isValid);
        }
    }
}