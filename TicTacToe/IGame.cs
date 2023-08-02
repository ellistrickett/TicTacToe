namespace TicTacToe
{
    public interface IGame
    {
        char[,] Board { get; }
        char[,] GetBoard();
        bool IsValidMove(int move);
    }
}
