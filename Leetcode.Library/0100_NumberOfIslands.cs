namespace Leetcode;

public static class NumberOfIslands {
    public static int RunNumberOfIslandsIterative(char[][] grid) {
        // If the grid is empty, there are no islands.
        if (grid.Length == 0 || grid[0].Length == 0) {
            return 0;
        }

        // Get the dimensions of the grid.
        var rows = grid.Length;
        var cols = grid[0].Length;
        // Initialize the count of islands to 0.
        var islands = 0;

        // Iterate over each cell in the grid.
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                // If a cell contains '1', it's the start of a new island.
                if (grid[i][j] == '1') {
                    // Increment the island count.
                    islands++;
                    // Use an iterative approach to mark all parts of the island.
                    MarkIslandIterative(grid, i, j, rows, cols);
                }
            }
        }

        // Return the total count of islands.
        return islands;
    }

    public static int RunNumberOfIslandsRecursive(char[][] grid) {
        // If the grid is empty, there are no islands.
        if (grid.Length == 0 || grid[0].Length == 0) {
            return 0;
        }

        // Get the dimensions of the grid.
        var rows = grid.Length;
        var cols = grid[0].Length;
        // Initialize the count of islands to 0.
        var islands = 0;

        // Iterate over each cell in the grid.
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                // If a cell contains '1', it's the start of a new island.
                if (grid[i][j] == '1') {
                    // Increment the island count.
                    islands++;
                    // Use a recursive approach to mark all parts of the island.
                    MarkIslandRecursive(grid, i, j, rows, cols);
                }
            }
        }

        // Return the total count of islands.
        return islands;
    }

    private static void MarkIslandIterative(char[][] grid, int startRow, int startCol, int rows, int cols) {
        // Create a stack for an iterative depth-first search.
        var stack = new Stack<(int row, int col)>();
        // Push the starting cell onto the stack.
        stack.Push((startRow, startCol));

        // Continue as long as there are cells to visit.
        while (stack.Count > 0) {
            // Pop a cell from the stack.
            var (row, col) = stack.Pop();

            // Check for invalid conditions: out of bounds or already visited/water.
            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] != '1') {
                continue;
            }

            // Mark the current cell as visited by changing '1' to '0'.
            grid[row][col] = '0';

            // Push all adjacent cells onto the stack to visit them.
            stack.Push((row + 1, col)); // Down
            stack.Push((row - 1, col)); // Up
            stack.Push((row, col + 1)); // Right
            stack.Push((row, col - 1)); // Left
        }
    }

    private static void MarkIslandRecursive(char[][] grid, int row, int col, int rows, int cols) {
        // Check for invalid conditions: out of bounds or already visited/water.
        if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] != '1') {
            return;
        }

        // Mark the current cell as visited by changing '1' to '0'.
        grid[row][col] = '0';

        // Recursively visit all adjacent cells.
        MarkIslandRecursive(grid, row + 1, col, rows, cols); // Down
        MarkIslandRecursive(grid, row - 1, col, rows, cols); // Up
        MarkIslandRecursive(grid, row, col + 1, rows, cols); // Right
        MarkIslandRecursive(grid, row, col - 1, rows, cols); // Left
    }
}