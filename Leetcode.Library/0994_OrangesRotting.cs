namespace Leetcode {
    public abstract class OrangesRotting {
        public static int RunOrangesRotting(int[][] grid) {
            // Handle empty grid
            if (grid.Length == 0 || grid[0].Length == 0) {
                return 0;
            }

            var rows = grid.Length;
            var cols = grid[0].Length;
            var queue = new Queue<(int r, int c)>();
            var fresh = 0;

            // Initialize queue with rotten oranges and count fresh ones
            for (var i = 0; i < rows; i++) {
                for (var j = 0; j < cols; j++) {
                    if (grid[i][j] == 2) {
                        queue.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1) {
                        fresh++;
                    }
                }
            }

            // If no fresh oranges, no time needed
            if (fresh == 0) {
                return 0;
            }

            var minutes = 0;
            var dr = new[] { -1, 1, 0, 0 };
            var dc = new[] { 0, 0, -1, 1 };

            // BFS level by level
            while (queue.Count > 0 && fresh > 0) {
                var size = queue.Count;
                minutes++;

                for (var i = 0; i < size; i++) {
                    var (r, c) = queue.Dequeue();

                    for (var d = 0; d < 4; d++) {
                        var nr = r + dr[d];
                        var nc = c + dc[d];

                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1) {
                            grid[nr][nc] = 2;
                            fresh--;
                            queue.Enqueue((nr, nc));
                        }
                    }
                }
            }

            return fresh == 0 ? minutes : -1;
        }
    }
}