using ConsoleManager;
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
            });

            var consoleManagerMock = new Mock<IConsoleManager>();
            var consoleUI = new ConsoleUI(gameMock.Object, consoleManagerMock.Object);

            var consoleUI = new ConsoleUI(gameMock.Object);

            // Act
            consoleUI.DisplayBoard();

            // Assert
            consoleManagerMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(9));
            consoleManagerMock.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
