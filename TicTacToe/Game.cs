namespace TicTacToe
{
    public class Game : IGame
    {
        private char[,] board;

        public Game()
        {
            board = new char[,]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };
        }

        public char[,] Board => board;

        public char[,] GetBoard()
        {
            return board;
        }

        public bool IsValidMove(int move)
        {
            GetRowAndColumn(move, out int row, out int col);

            if (board[row, col] != '-')
            {
                return false;
            }

            return true;
        }

        public void MakeMove(int move, char playerSymbol)
        {
            GetRowAndColumn(move, out int row, out int col);

            board[row, col] = playerSymbol;
        }

        public bool IsGameOver()
        {
            return false;
        }

        private void GetRowAndColumn(int move, out int row, out int col)
        {
            row = (move - 1) / 3;
            col = (move - 1) % 3;
        }
    }
}
