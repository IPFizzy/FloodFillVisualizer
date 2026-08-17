# Flood Fill Visualizer

A small **C# .NET console visualizer** that demonstrates recursive flood fill across a randomly generated grid containing obstacle walls.

<p>
  <img src="https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/Algorithm-Flood%20Fill-238636?style=flat-square" alt="Flood Fill" />
  <img src="https://img.shields.io/badge/Status-Complete-238636?style=flat-square" alt="Project status: Complete" />
</p>

## Overview

Flood Fill Visualizer builds a 20×20 grid, places several randomly positioned rectangular wall outlines, and lets the user choose a starting cell. A recursive four-direction flood-fill algorithm then expands through every connected empty cell that can be reached without crossing a wall.

The console redraws the grid as cells are filled, turning the recursive traversal into a visible animation rather than only printing a final result.

## Features

- Recursive four-direction flood-fill algorithm
- 20×20 grid visualization
- Randomly generated obstacle walls
- Animated traversal in the console
- Row and column coordinate labels
- Range-validated user input
- Wall detection before the fill begins
- Filled-cell counter
- Color-coded empty, wall, and filled cells
- Defensive board-construction validation

## Board Symbols

```text
W = wall
. = empty cell
~ = filled cell
```

Walls are displayed separately from traversable cells, and filled cells are highlighted as the recursive search progresses.

## How the Algorithm Works

The selected starting cell is processed first. For each empty cell, the program:

1. Marks the current cell as filled.
2. Recursively checks the cell to the north.
3. Recursively checks the cell to the east.
4. Recursively checks the cell to the south.
5. Recursively checks the cell to the west.

A recursive branch stops immediately when it reaches:

- A position outside the board
- A wall
- A cell that has already been filled

Marking a cell before exploring its neighbors prevents the algorithm from repeatedly revisiting the same location.

## Example Traversal

A simplified region might begin as:

```text
. . . W .
. . . W .
. . . W .
W W W W .
. . . . .
```

Starting in the upper-left region fills only the connected cells that can be reached without passing through the wall:

```text
~ ~ ~ W .
~ ~ ~ W .
~ ~ ~ W .
W W W W .
. . . . .
```

The actual application uses a larger randomly generated board, so each run can produce a different traversal pattern.

## Random Obstacles

`BoardModel` starts every grid cell as empty and then generates several rectangular wall outlines at random positions.

The default application configuration uses:

```text
Board size: 20 × 20
Wall shapes: 3
```

Shapes are allowed to overlap, which can create more complex boundaries and connected regions.

## Complexity

For a board containing `R × C` cells, flood fill visits each reachable cell at most once.

```text
Time:  O(R × C)
Space: O(R × C) worst case
```

The space bound comes from the recursive call stack. A large uninterrupted region can produce many nested calls, which is one reason iterative queue-based flood fill is often preferred for very large grids. For this 20×20 visualization, recursion keeps the algorithm easy to follow while remaining practical.

## Technology

| Area | Technology |
| --- | --- |
| Language | C# |
| Runtime | .NET 10 |
| Interface | Console |
| Algorithm | Recursive flood fill |
| Data Structure | Two-dimensional array |

## Project Structure

```text
FloodFillVisualizer/
├── FloodFillRecursion/
│   ├── Models/
│   │   ├── BoardModel.cs
│   │   └── CellModel.cs
│   ├── Program.cs
│   └── FloodFillRecursion.csproj
└── FloodFillRecursion.slnx
```

### `BoardModel`

Creates the two-dimensional cell grid and places randomized wall shapes.

### `CellModel`

Stores each cell's row, column, and current contents.

### `Program.cs`

Handles console interaction, board rendering, coordinate validation, animation, and the recursive flood-fill algorithm.

## Running the Project

### Requirements

- .NET 10 SDK, or
- Visual Studio with .NET development support

Clone the repository:

```bash
git clone https://github.com/IPFizzy/FloodFillVisualizer.git
cd FloodFillVisualizer
```

Run the application:

```bash
dotnet run --project FloodFillRecursion/FloodFillRecursion.csproj
```

Or open `FloodFillRecursion.slnx` in Visual Studio and run the project.

## Practice Project Context

This repository is preserved as a completed algorithm practice project. It demonstrates recursive traversal, two-dimensional arrays, boundary conditions, visited-state tracking, randomized grid generation, console visualization, and termination through explicit stopping conditions.

## Author

**Keon Bushman**  
Software Development Student & IT Professional  
[GitHub Profile](https://github.com/IPFizzy)
