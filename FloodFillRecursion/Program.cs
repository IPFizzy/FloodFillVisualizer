using FloodFillRecursion.Models;

const int boardSize = 20;
const int shapeCount = 3;
const int animationDelayMilliseconds = 15;

BoardModel board = new BoardModel(boardSize, shapeCount);

Console.WriteLine("Recursive Flood Fill Visualizer");
Console.WriteLine("-------------------------------");
Console.WriteLine("W = wall   . = empty   ~ = filled");
Console.WriteLine();
PrintBoard(board);

int startRow = ReadCoordinate("Enter the starting row", board.Size) - 1;
int startColumn = ReadCoordinate("Enter the starting column", board.Size) - 1;

if (board.Grid[startRow, startColumn].Contents == "W")
{
    Console.WriteLine();
    Console.WriteLine("The selected cell is a wall, so there is nothing to fill.");
    return;
}

int filledCells = 0;
FloodFill(board, startRow, startColumn, ref filledCells, animationDelayMilliseconds);

Console.Clear();
Console.WriteLine("Recursive Flood Fill Visualizer");
Console.WriteLine("-------------------------------");
Console.WriteLine("W = wall   . = empty   ~ = filled");
Console.WriteLine();
PrintBoard(board);

Console.ResetColor();
Console.WriteLine();
Console.WriteLine($"Flood fill complete. Filled cells: {filledCells}");
Console.WriteLine($"Starting position: row {startRow + 1}, column {startColumn + 1}");

static void FloodFill(
    BoardModel board,
    int row,
    int column,
    ref int filledCells,
    int animationDelayMilliseconds)
{
    if (!IsOnBoard(board, row, column))
    {
        return;
    }

    if (board.Grid[row, column].Contents != "E")
    {
        return;
    }

    board.Grid[row, column].Contents = "F";
    filledCells++;

    if (animationDelayMilliseconds > 0)
    {
        Console.Clear();
        Console.WriteLine("Recursive Flood Fill Visualizer");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("W = wall   . = empty   ~ = filled");
        Console.WriteLine();
        PrintBoard(board);
        Console.WriteLine();
        Console.WriteLine($"Filling from row {row + 1}, column {column + 1}...");
        Thread.Sleep(animationDelayMilliseconds);
    }

    FloodFill(board, row - 1, column, ref filledCells, animationDelayMilliseconds);
    FloodFill(board, row, column + 1, ref filledCells, animationDelayMilliseconds);
    FloodFill(board, row + 1, column, ref filledCells, animationDelayMilliseconds);
    FloodFill(board, row, column - 1, ref filledCells, animationDelayMilliseconds);
}

static bool IsOnBoard(BoardModel board, int row, int column)
{
    return row >= 0 && row < board.Size &&
           column >= 0 && column < board.Size;
}

static int ReadCoordinate(string prompt, int boardSize)
{
    while (true)
    {
        Console.Write($"{prompt} (1-{boardSize}): ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value >= 1 && value <= boardSize)
        {
            return value;
        }

        Console.WriteLine($"Please enter a whole number from 1 through {boardSize}.");
    }
}

static void PrintBoard(BoardModel board)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("   ");

    for (int column = 0; column < board.Size; column++)
    {
        Console.Write($"{column + 1,3}");
    }

    Console.WriteLine();

    for (int row = 0; row < board.Size; row++)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{row + 1,2} ");

        for (int column = 0; column < board.Size; column++)
        {
            switch (board.Grid[row, column].Contents)
            {
                case "W":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  W");
                    break;

                case "F":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("  ~");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("  .");
                    break;
            }
        }

        Console.WriteLine();
    }

    Console.ResetColor();
}
