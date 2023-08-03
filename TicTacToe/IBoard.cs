public interface IBoard
{
    char[,] GetBoard();
    void SetCell(int row, int col, char symbol);
}
