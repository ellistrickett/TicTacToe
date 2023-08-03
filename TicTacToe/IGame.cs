namespace TicTacToe
{
    public interface IGame
    {
        bool IsValidMove(int row, int col);
        bool IsGameOver();
        void MakeComputerMove(char playerSymbol);
    }
}
