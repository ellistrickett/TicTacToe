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
    }
}