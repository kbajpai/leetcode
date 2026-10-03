namespace Leetcode {
    public abstract class ShortestPathBinaryMatrix {
        public static int RunShortestPathBinaryMatrix(int[][] grid) {
            var n = grid.Length;

            switch (n) {
                // Handle edge cases
                case 0:
                    return -1;
                case 1:
                    return grid[0][0] == 0 ? 1 : -1;
            }

            // Check if start or end is blocked
            if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0) {
                return -1;
            }

            // 8 directions: up, down, left, right, and 4 diagonals
            int[] dr = [-1, -1, -1, 0, 0, 1, 1, 1];
            int[] dc = [-1, 0, 1, -1, 1, -1, 0, 1];

            var queue = new Queue<(int row, int col, int pathLen)>();
            queue.Enqueue((0, 0, 1));
            grid[0][0] = 1; // Mark as visited

            while (queue.Count > 0) {
                var (row, col, pathLen) = queue.Dequeue();

                // Early termination: first time we reach destination is optimal (BFS guarantees shortest path)
                if (row == n - 1 && col == n - 1) {
                    return pathLen;
                }

                // Explore all 8 directions
                for (var i = 0; i < 8; i++) {
                    var newRow = row + dr[i];
                    var newCol = col + dc[i];

                    // Check bounds and if cell is free (0)
                    if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && grid[newRow][newCol] == 0) {
                        grid[newRow][newCol] = 1; // Mark as visited
                        queue.Enqueue((newRow, newCol, pathLen + 1));
                    }
                }
            }

            return -1; // No path found
        }
    }
}