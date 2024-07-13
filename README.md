# Console Maze Game

A simple console-based maze game written in C#. Navigate through a randomly generated maze using arrow keys and find the exit. Perfect for learning basic game development and C# programming.

## Features
- **Randomly Generated Maze**: Each maze is generated at runtime using the Depth-First Search (DFS) algorithm.
- **ASCII Art Maze**: The maze is displayed using ASCII characters, with walls (`#`) and paths (`' '`).
- **Player Movement**: Move the player (`P`) through the maze using the arrow keys.
- **Exit Point**: The goal is to find the exit (`E`).

## Maze Representation
Each block of the maze (wall, path, player, exit) occupies a 2x2 space in the console for better visibility.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine

### Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/armandomeabe/Console-Maze-Game.git
    cd Console-Maze-Game
    ```

2. Build and run the project:
    ```sh
    dotnet run
    ```

## How to Play
- Use the arrow keys to move the player (`P`) through the maze.
- Find the exit (`E`) to win the game.
- The maze is displayed using ASCII characters, with each cell occupying a 2x2 space for better visibility.

## Code Overview
The maze is generated using a Depth-First Search (DFS) algorithm. The player's position and the exit are updated in real-time as you navigate through the maze.

## Contributing
Feel free to submit issues, fork the repository, and make pull requests. Contributions are welcome!

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.