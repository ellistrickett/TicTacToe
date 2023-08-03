using ConsoleManager;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    public class GameFixture : IClassFixture<Game>, IDisposable
    {
        public Mock<IBoard> MockBoard { get; private set; }
        public Mock<IRandomNumberGenerator> MockRandomNumberGenerator { get; private set; }
        public IGame Game { get; private set; }

        public GameFixture()
        {
            MockBoard = new Mock<IBoard>();
            MockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();

            MockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            });

            Game = new Game(MockBoard.Object, MockRandomNumberGenerator.Object);
        }

        public void Dispose()
        {
            MockRandomNumberGenerator.Reset();
            MockBoard.Reset();
        }
    }
}
