using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Program_Main_ShouldCallConsoleUIRun()
        {
            // Arrange
            var consoleUIMock = new Mock<IConsoleUI>();
            var program = new Program();
            var args = new string[] { };

            // Act
            Program.Main(args);

            // Assert
            consoleUIMock.Verify(m => m.Run(args), Times.Once);
        }
    }
}
