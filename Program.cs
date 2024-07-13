using System;
using System.Collections.Generic;

class Maze
{
    static char[,] maze;
    static int rows = 11;
    static int columns = 48;
    static int playerRow = 1;
    static int playerColumn = 1;
    static int exitRow = rows - 2;
    static int exitColumn = columns - 2;
    static Random random = new Random();

    static void Main()
    {
        GenerateMaze();
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            DrawMaze();
            key = Console.ReadKey(true);
            MovePlayer(key.Key);
        } while (playerRow != exitRow || playerColumn != exitColumn);

        Console.Clear();
        Console.WriteLine("Congratulations, you found the exit!");
    }

    // Generates the maze using a Depth-First Search (DFS) algorithm
    static void GenerateMaze()
    {
        // Initialize the maze with walls ('#')
        maze = new char[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                maze[i, j] = '#';
            }
        }

        // Stack to keep track of the path
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((playerRow, playerColumn));
        maze[playerRow, playerColumn] = ' ';

        // Possible movements: up, down, left, right
        int[] deltaRow = { -2, 2, 0, 0 };
        int[] deltaColumn = { 0, 0, -2, 2 };

        while (stack.Count > 0)
        {
            var (currentRow, currentColumn) = stack.Peek();
            List<int> directions = new List<int> { 0, 1, 2, 3 };
            bool moved = false;

            // Try moving in random directions
            while (directions.Count > 0)
            {
                int index = random.Next(directions.Count);
                int direction = directions[index];
                directions.RemoveAt(index);

                int newRow = currentRow + deltaRow[direction];
                int newColumn = currentColumn + deltaColumn[direction];

                // Check if the new position is within bounds and has not been visited
                if (newRow > 0 && newRow < rows - 1 && newColumn > 0 && newColumn < columns - 1 && maze[newRow, newColumn] == '#')
                {
                    maze[newRow, newColumn] = ' ';
                    maze[currentRow + deltaRow[direction] / 2, currentColumn + deltaColumn[direction] / 2] = ' ';
                    stack.Push((newRow, newColumn));
                    moved = true;
                    break;
                }
            }

            // If no movement is possible, backtrack
            if (!moved)
            {
                stack.Pop();
            }
        }

        // Set the exit point
        maze[exitRow, exitColumn] = 'E';
    }

    // Draws the maze in the console
    static void DrawMaze()
    {
        for (int row = 0; row < maze.GetLength(0); row++)
        {
            for (int subRow = 0; subRow < 2; subRow++) // Each row of the maze is drawn twice
            {
                for (int column = 0; column < maze.GetLength(1); column++)
                {
                    char toPrint = maze[row, column];
                    if (row == playerRow && column == playerColumn)
                    {
                        toPrint = 'P'; // Player position
                    }
                    for (int subColumn = 0; subColumn < 2; subColumn++) // Each column of the maze is drawn twice
                    {
                        Console.Write(toPrint);
                    }
                }
                Console.WriteLine();
            }
        }
    }

    // Moves the player based on the input key
    static void MovePlayer(ConsoleKey key)
    {
        int newRow = playerRow;
        int newColumn = playerColumn;

        // Determine new position based on key press
        switch (key)
        {
            case ConsoleKey.UpArrow:
                newRow--;
                break;
            case ConsoleKey.DownArrow:
                newRow++;
                break;
            case ConsoleKey.LeftArrow:
                newColumn--;
                break;
            case ConsoleKey.RightArrow:
                newColumn++;
                break;
        }

        // Check if the new position is a valid move (empty space or exit)
        if (maze[newRow, newColumn] == ' ' || maze[newRow, newColumn] == 'E')
        {
            playerRow = newRow;
            playerColumn = newColumn;
        }
    }
}