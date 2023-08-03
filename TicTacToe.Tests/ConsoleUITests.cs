using ConsoleManager;
using Moq;
using System;

namespace TicTacToe.Tests
{
    public class ConsoleUITests
    {
        private readonly ConsoleUIFixture _fixture;

        public ConsoleUITests()
        {
            _fixture = new ConsoleUIFixture();
        }

        [Fact]
        public void ConsoleUI_DisplayBoard_ShouldDisplayCorrectBoard()
        {
            // Arrange
            _fixture.MockBoard.Setup(m => m.GetBoard()).Returns(new char[,]
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
        public void ConsoleUI_MakePlayerMove_ShouldPromptPlayer()
        {
            // Arrange
            string expectedPrompt = "Enter your move (1-9): ";
            string input = "5";
            _fixture.MockConsoleManager.Setup(m => m.ReadLine())
                                      .Returns(input);

            // Act
            _fixture.ConsoleUI.PromptHumanMove();

            // Assert
            _fixture.MockConsoleManager.Verify(m => m.Write(expectedPrompt), Times.Once);
            _fixture.MockConsoleManager.Verify(m => m.ReadLine(), Times.Once);
        }
        [Fact]
        public void ConsoleUI_MakePlayerMove_InputLetterPromptsUserForNumber()
        {
            // Arrange
            string input = "L";
            _fixture.MockConsoleManager.SetupSequence(m => m.ReadLine())
                                      .Returns(input)
                                      .Returns("5");

            // Act
            _fixture.ConsoleUI.PromptHumanMove();

            // Assert
            _fixture.MockConsoleManager.Verify(m => m.Write("Invalid input! Please enter a number (1-9): "), Times.Once);
            _fixture.MockConsoleManager.Verify(m => m.ReadLine(), Times.Exactly(2));
        }

        [Fact]
        public void ConsoleUI_MakePlayerMove_InputInavlidNumberPromptsUserForNumber()
        {
            // Arrange
            string input = "11";
            _fixture.MockConsoleManager.SetupSequence(m => m.ReadLine())
                                      .Returns(input)
                                      .Returns("5");

            // Act
            _fixture.ConsoleUI.PromptHumanMove();

            // Assert
            _fixture.MockConsoleManager.Verify(m => m.Write("Invalid input! Please enter a number (1-9): "), Times.Once);
            _fixture.MockConsoleManager.Verify(m => m.ReadLine(), Times.Exactly(2));
        }


        [Fact]
        public void ConsoleUI_MakePlayerMove_InputOccupiedCellPromptsAnotherMove()
        {
            // Arrange
            string input = "7";
            _fixture.MockConsoleManager.SetupSequence(m => m.ReadLine())
                                      .Returns(input)
                                      .Returns("5");

            _fixture.MockGame.SetupSequence(m => m.MakeHumanMove(It.IsAny<int>()))
                .Returns("Invalid move! Cell already occupied. Please enter another move: ")
                .Returns((string?)null);

            // Act
            _fixture.ConsoleUI.PromptHumanMove();

            // Assert
            _fixture.MockConsoleManager.Verify(m => m.Write("Invalid move! Cell already occupied. Please enter another move: "), Times.Once);
            _fixture.MockConsoleManager.Verify(m => m.ReadLine(), Times.Exactly(2));
        }
    }
}
