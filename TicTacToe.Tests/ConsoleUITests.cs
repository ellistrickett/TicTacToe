using Moq;
using System;

namespace TicTacToe.Tests
{
    public class ConsoleUITests
    {
        [Fact]
        public void ConsoleUI_DisplayBoard_ShouldDisplayCorrectBoard()
        {
            // Arrange
            var gameMock = new Mock<IGame>();
            gameMock.Setup(g => g.GetBoard()).Returns(new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };

            var consoleUI = new ConsoleUI(gameMock.Object);

            // Act
            consoleUI.DisplayBoard();

            // Assert

        }
    }
}
