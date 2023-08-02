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
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;

            if (board[row, col] != '-')
            {
                return false;
            }

            return true;
        }
    }
}
