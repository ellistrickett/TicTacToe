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
        public void PromptHumanMove()
        {
            bool isValidMove = false;

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
                    string? invalidMovePrompt = _game.MakeHumanMove(move);

                    if (invalidMovePrompt != null)
                    {
                        _consoleManager.Write(invalidMovePrompt);
                    }
                    else
                    {
                        isValidMove = true;
                    }
                }

            } while (!isValidMove);          
        }

        public void Run(string[] args)
        {
            while (!_game.IsGameOver())
            {
                DisplayBoard();
                PromptHumanMove();
                DisplayBoard();

                //Code Smell
                if (_game.IsGameOver())
                {
                    break;
                }

                Console.WriteLine("Computer is plotting its move...");
                //Should Interface and Test
                Thread.Sleep(2000);

                _game.MakeComputerMove('O');
            }

            Console.WriteLine(_game.GameResult);
        }
    }
}
