
namespace TicTacToe
{
    public static class BoardUtility
    {
        public static void GetRowAndColumn(int move, out int row, out int col)
        {
            row = (move - 1) / 3;
            col = (move - 1) % 3;
        }
    }
}
