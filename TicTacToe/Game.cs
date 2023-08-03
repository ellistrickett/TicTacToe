
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
        //Code Smell
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

        //Code Smell Maybe Keep Track Of Moves
        //Saves Iterating Through Board All The Time
        public bool IsGameOver()
        {
            char[,] board = _board.GetBoard();

            if (IsLessThan5Moves(board))
            {
                return false;
            }

            if (IsBoardFull(board))
            {
                GameResult = "It's a Draw!";
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
                //Check rows
                if (board[i, 0] == playerSymbol && board[i, 1] == playerSymbol && board[i, 2] == playerSymbol)
                {
                    GameResult = $"Congratulations Player {playerSymbol}, You Win!";
                    return true;
                }

                // Check columns
                if (board[0, i] == playerSymbol && board[1, i] == playerSymbol && board[2, i] == playerSymbol)
                {
                    GameResult = $"Congratulations Player {playerSymbol}, You Win!";
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == playerSymbol && board[1, 1] == playerSymbol && board[2, 2] == playerSymbol)
            {
                GameResult = $"Congratulations Player {playerSymbol}, You Win!";
                return true;
            }

            if (board[0, 2] == playerSymbol && board[1, 1] == playerSymbol && board[2, 0] == playerSymbol)
            {
                GameResult = $"Congratulations Player {playerSymbol}, You Win!";
                return true;
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
