﻿using ConsoleManager;
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
        public Mock<IBoard> MockBoard { get; private set; }
        public ConsoleUI ConsoleUI { get; private set; }

        public ConsoleUIFixture()
        {
            MockConsoleManager = new Mock<IConsoleManager>();
            MockGame = new Mock<IGame>();
            MockBoard = new Mock<IBoard>();

            int expectedRow = 0;
            int expectedCol = 0;

            MockGame.Setup(m => m.TryGetRowCol(It.IsAny<int>(), out expectedRow, out expectedCol))
                       .Returns(true);

            MockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            });

            ConsoleUI = new ConsoleUI(MockConsoleManager.Object, MockGame.Object, MockBoard.Object);
        }

        public void Dispose()
        {
            MockConsoleManager.Reset();
            MockGame.Reset();
            MockBoard.Reset();
        }
    }
}
