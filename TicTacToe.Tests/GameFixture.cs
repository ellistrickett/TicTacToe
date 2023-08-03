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
        public Mock<IRandomNumberGenerator> MockRandomNumberGenerator { get; private set; }
        public Game Game { get; private set; }

        public Game()
        {
            MockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();

            Game = new Game(MockRandomNumberGenerator.Object);
        }

        public void Dispose()
        {
            MockRandomNumberGenerator.Reset();
        }
    }
}
