using ConsoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleUI : IConsoleUI
    {
        private readonly IConsoleManager _consoleManager;
        private readonly IGame _game;

        public ConsoleUI(IConsoleManager consoleManager, IGame game)
        {
            _consoleManager = consoleManager;
            _game = game;
        }

        public void DisplayBoard()
        {
            char[,] board = _game.GetBoard();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _consoleManager.Write(board[row, col] + " ");
                }
                _consoleManager.WriteLine();
            }
        }
        public int GetPlayerMove()
        {
            int move;
            bool isValidMove = false;

            _consoleManager.Write("Enter your move (1-9): ");
            
            do
            {
                string input = _consoleManager.ReadLine();

                if (!int.TryParse(input, out move) || move < 1 || move > 9)
                {
                    _consoleManager.Write("Invalid input! Please enter a number (1-9): ");
                }
                else
                {
                    isValidMove = _game.IsValidMove(move);
                    if (!isValidMove)
                    {
                        _consoleManager.Write("Invalid move! Cell already occupied. Please enter another move: ");
                    }
                }

            } while (!isValidMove);

            return move;

        }

        public void Run(string[] args)
        {
            DisplayBoard();
            int move = GetPlayerMove();
            _game.MakeMove(move, 'X');
        }
    }
}
