public interface IBoard
{
    char[,] GetBoard();
    void SetCell(int row, int col, char symbol);
    char GetCell(int row, int col);
    void SetBoard(char[,] newBoard);
}
