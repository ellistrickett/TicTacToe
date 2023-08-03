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
        public void MakePlayerMove()
        {
            int move;
            bool isValidMove = false;
            int row = 10;
            int col = 10;

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
                    BoardUtility.GetRowAndColumn(move, out row, out col);

                    isValidMove = _game.IsValidMove(row, col);
                    if (!isValidMove)
                    {
                        _consoleManager.Write("Invalid move! Cell already occupied. Please enter another move: ");
                    }
                }

            } while (!isValidMove);

            _board.SetCell(row, col, 'X');

        }

        public void Run(string[] args)
        {
            while (!_game.IsGameOver())
            {
                DisplayBoard();
                MakePlayerMove();
                DisplayBoard();

                Console.WriteLine("Computer is plotting its move...");
                //Should Interface and Test
                Thread.Sleep(2000);

                _game.MakeComputerMove('O');
            }
        }
    }
}
