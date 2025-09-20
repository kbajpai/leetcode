namespace Leetcode;

public abstract class NumberOfIslands {
    public static int RunNumberOfIslands(char[][] grid) {
        if (grid.Length == 0 || grid[0].Length == 0)
            return 0;
        
        var rows = grid.Length;
        var cols = grid[0].Length;
        var islands = 0;

        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                if (grid[i][j] == '1') {
                    islands++;
                    MarkIslandIterative(grid, i, j, rows, cols);
                }
            }
        }

        return islands;
    }

    private static void MarkIslandIterative(char[][] grid, int startRow, int startCol, int rows, int cols) {
        var stack = new Stack<(int row, int col)>();
        stack.Push((startRow, startCol));
        
        while (stack.Count > 0) {
            var (row, col) = stack.Pop();
            
            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] != '1')
                continue;
            
            // Mark as visited by changing '1' to '0'
            grid[row][col] = '0';
            
            // Add adjacent cells to stack
            stack.Push((row + 1, col));
            stack.Push((row - 1, col));
            stack.Push((row, col + 1));
            stack.Push((row, col - 1));
        }
    }
}