namespace FloodFillRecursion.Models
{
    internal class BoardModel
    {
        public int Size { get; }
        public CellModel[,] Grid { get; }
        public int NumShapes { get; }

        public BoardModel(int size, int numShapes)
        {
            if (size < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Board size must be at least 3.");
            }

            if (numShapes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numShapes), "Shape count cannot be negative.");
            }

            Size = size;
            NumShapes = numShapes;
            Grid = new CellModel[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    Grid[row, column] = new CellModel(row, column, "E");
                }
            }

            PlaceShapes();
        }

        private void PlaceShapes()
        {
            int shapeSize = Math.Max(3, Size / 2);

            for (int shape = 0; shape < NumShapes; shape++)
            {
                int row = Random.Shared.Next(0, Size - shapeSize + 1);
                int column = Random.Shared.Next(0, Size - shapeSize + 1);

                for (int offset = 0; offset < shapeSize; offset++)
                {
                    Grid[row, column + offset].Contents = "W";
                    Grid[row + shapeSize - 1, column + offset].Contents = "W";
                    Grid[row + offset, column].Contents = "W";
                    Grid[row + offset, column + shapeSize - 1].Contents = "W";
                }
            }
        }
    }
}
