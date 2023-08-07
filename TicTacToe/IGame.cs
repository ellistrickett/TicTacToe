namespace TicTacToe
{
    public interface IGame
    {
        string GameResult { get; }
        bool TryGetRowCol(int move, out int row, out int col);
        bool IsGameOver();
        void MakeComputerMove(char playerSymbol);
    }
}
