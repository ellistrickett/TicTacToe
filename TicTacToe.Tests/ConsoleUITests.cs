using ConsoleManager;
using Moq;
using System;

namespace TicTacToe.Tests
{
    public class ConsoleUITests : IClassFixture<ConsoleUIFixture>
    {
        private readonly ConsoleUIFixture _fixture;

        public ConsoleUITests(ConsoleUIFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ConsoleUI_DisplayBoard_ShouldDisplayCorrectBoard()
        {
            // Arrange
            _fixture.MockGame.Setup(g => g.GetBoard()).Returns(new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            });

            // Act
            _fixture.ConsoleUI.DisplayBoard();

            // Assert
            _fixture.MockConsoleManager.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(9));
            _fixture.MockConsoleManager.Verify(m => m.WriteLine(), Times.Exactly(3));
        }
    }
}
