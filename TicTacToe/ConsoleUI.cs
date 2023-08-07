using ConsoleManager;

namespace TicTacToe
{
    public class ConsoleUI : IConsoleUI
    {
        private readonly IConsoleManager _consoleManager;
        private readonly IGame _game;
        private readonly IBoard _board;

        public ConsoleUI(IConsoleManager consoleManager, IGame game, IBoard board)
        {
            _consoleManager = consoleManager;
            _game = game;
            _board = board;
        }

        public void DisplayBoard()
        {
            char[,] board = _board.GetBoard();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _consoleManager.Write(board[row, col] + " ");
                }
                _consoleManager.WriteLine();
            }
        }
        public (int, int) GetHumanMove()
        {
            bool TryGetRowCol = false;

            _consoleManager.Write("Enter your move (1-9): ");
            
            do
            {
                string input = _consoleManager.ReadLine();

                if (!int.TryParse(input, out int move) || move < 1 || move > 9)
                {
                    _consoleManager.Write("Invalid input! Please enter a number (1-9): ");
                }
                else
                {
                    if (!_game.TryGetRowCol(move, out int row, out int col))
                    {
                        _consoleManager.Write("Invalid move! Cell already occupied. Please enter another move: ");
                    }
                    else
                    {
                        return (row, col);
                    }
                }

            } while (!TryGetRowCol);

            return (-1, -1);
        }

        public void Run(string[] args)
        {
            while (!_game.IsGameOver())
            {
                DisplayBoard();

                var rowCol = GetHumanMove();
                _board.SetCell(rowCol.Item1, rowCol.Item2, 'X');

                DisplayBoard();

                if (_game.IsGameOver())
                {
                    break;
                }

                Console.WriteLine("Computer is plotting its move...");
                Thread.Sleep(2000);

                _game.MakeComputerMove('O');
            }

            Console.WriteLine(_game.GameResult);
        }
    }
}
