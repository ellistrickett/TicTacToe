namespace TicTacToe
{
    public interface IGame
    {
        string GameResult { get; }
        bool IsValidMove(int row, int col);
        bool IsGameOver();
        void MakeComputerMove(char playerSymbol);
    }
}
