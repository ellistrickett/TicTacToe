
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

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;

        }
    }
}
