using ConsoleManager;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    public class ConsoleUIFixture : IClassFixture<ConsoleUI>, IDisposable
    {
        public Mock<IConsoleManager> MockConsoleManager { get; private set; }
        public Mock<IGame> MockGame { get; private set; }
        public ConsoleUI ConsoleUI { get; private set; }

        public ConsoleUIFixture()
        {
            MockConsoleManager = new Mock<IConsoleManager>();
            MockGame = new Mock<IGame>();

            MockGame.Setup(m => m.IsValidMove(It.IsAny<int>()))
                       .Returns(true);

            ConsoleUI = new ConsoleUI(MockConsoleManager.Object, MockGame.Object);
        }

        public void Dispose()
        {
            MockConsoleManager.Reset();
            MockGame.Reset();
        }
    }
}
