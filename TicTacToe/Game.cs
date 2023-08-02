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

        public char[,] GetBoard()
        {
            return board;
        }

        public bool IsValidMove(int move)
        {
            return true;
        }
    }
}
