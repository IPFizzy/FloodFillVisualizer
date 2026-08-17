namespace FloodFillRecursion.Models
{
    internal class CellModel
    {
        public int Row { get; }
        public int Column { get; }
        public string Contents { get; set; }

        public CellModel(int row, int column, string contents)
        {
            Row = row;
            Column = column;
            Contents = contents;
        }
    }
}
