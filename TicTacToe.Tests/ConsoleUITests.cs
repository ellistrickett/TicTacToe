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

        [Fact]
        public void ConsoleUI_GetPlayerMove_ShouldPromptPlayerAndReturnMove()
        {
            // Arrange
            string expectedPrompt = "Enter your move (1-9): ";
            string input = "5";
            _fixture.MockConsoleManager.Setup(m => m.ReadLine())
                                      .Returns(input);

            // Act
            int move = _fixture.ConsoleUI.GetPlayerMove();

            // Assert
            _fixture.MockConsoleManager.Verify(m => m.Write(expectedPrompt), Times.Once);
            _fixture.MockConsoleManager.Verify(m => m.ReadLine(), Times.Once);
            Assert.Equal(5, move);
        }
    }
}
