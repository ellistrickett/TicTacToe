
namespace TicTacToe
{
    public class Game : IGame
    {
        private readonly IBoard _board;
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public Game(IBoard board, IRandomNumberGenerator randomNumberGenerator)
        {
            _board = board;
            _randomNumberGenerator = randomNumberGenerator;
        }
        public string GameResult { get; private set; }

        public bool IsValidMove(int row, int col)
        {
            if (_board.GetCell(row, col) != '-')
            {
                return false;
            }

            return true;
        }

        public void MakeComputerMove(char playerSymbol)
        {
            int move;
            int row;
            int col;

            do
            {
                move = _randomNumberGenerator.Next();

                BoardUtility.GetRowAndColumn(move, out row, out col);

            } while (!IsValidMove(row, col));

            _board.SetCell(row, col, playerSymbol);
        }

        public bool IsGameOver()
        {
            char[,] board = _board.GetBoard();

            if (IsLessThan5Moves(board))
            {
                return false;
            }

            if (IsBoardFull(board))
            {
                GameResult = "Draw";
                return true;
            }

            if (IsPlayerWin('X', board) || IsPlayerWin('O', board))
            {
                return true;
            }

            return false;

        }

        private bool IsPlayerWin(char playerSymbol, char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == playerSymbol && board[i, 1] == playerSymbol && board[i, 2] == playerSymbol)
                {
                    GameResult = playerSymbol.ToString();
                    return true;
                }

                // Check columns
                if (board[0, i] == playerSymbol && board[1, i] == playerSymbol && board[2, i] == playerSymbol)
                {
                    GameResult = playerSymbol.ToString();
                    return true;
                }
            }

            return false;
        }

        private bool IsBoardFull(char[,] board)
        {
            return board.Cast<char>().All(cell => cell != '-');
        }
        private bool IsLessThan5Moves(char[,] board)
        {
            return board.Cast<char>().Count(cell => cell != '-') < 5;
        }
    }
}
