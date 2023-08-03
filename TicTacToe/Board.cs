public class Board : IBoard
{
    private char[,] _board;

    public Board()
    {
        _board = new char[,]
        {
            { '-', '-', '-' },
            { '-', '-', '-' },
            { '-', '-', '-' }
        };
    }

    public char[,] GetBoard()
    {
        return _board;
    }

    public void SetCell(int row, int col, char symbol)
    {
        _board[row, col] = symbol;
    }

    public char GetCell(int row, int col)
    {
        return _board[row, col];
    }
    public void SetBoard(char[,] newBoard)
    {
        _board = newBoard;
    }

}
