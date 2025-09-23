namespace Leetcode;

public static class MinReorder {
    /// <summary>
    ///     Finds minimum number of edges to reverse so all cities can reach city 0.
    ///     Uses DFS to traverse from city 0 and counts edges pointing away that need reversal.
    ///     Time: O(n), Space: O(n)
    /// </summary>
    public static int RunMinReorder(int n, int[][] connections) {
        // Edge cases: single city or no connections
        if (n <= 1 || connections == null || connections.Length == 0) {
            return 0;
        }

        var adj = new List<(int, int)>[n];
        for (var i = 0; i < n; i++) {
            adj[i] = [];
        }

        foreach (var c in connections) {
            if (c == null || c.Length < 2) {
                continue;
            }

            var u = c[0];
            var v = c[1];
            if (u < 0 || u >= n || v < 0 || v >= n) {
                continue;
            }

            adj[u].Add((v, 1)); // 1 represents an original edge u -> v
            adj[v].Add((u, 0)); // 0 represents a reversed edge v -> u
        }

        var seen = new bool[n];
        seen[0] = true;

        return DFS(0);

        int DFS(int node) {
            var revs = 0;

            foreach (var (neighbor, direction) in adj[node]) {
                if (!seen[neighbor]) {
                    seen[neighbor] = true;
                    revs += direction; // Add 1 if it's an original edge (node -> neighbor)
                    revs += DFS(neighbor);
                }
            }

            return revs;
        }
    }

    /// <summary>
    ///     Finds minimum number of edges to reverse so all cities can reach city 0.
    ///     Uses BFS to traverse from city 0 and counts edges pointing away that need reversal.
    ///     Time: O(n), Space: O(n)
    /// </summary>
    public static int RunMinReorderIterative(int n, int[][] connections) {
        // Edge cases: single city or no connections
        if (n <= 1 || connections == null || connections.Length == 0) {
            return 0;
        }

        var adj = new List<(int, int)>[n];
        for (var i = 0; i < n; i++) {
            adj[i] = [];
        }

        foreach (var c in connections) {
            if (c == null || c.Length < 2) {
                continue;
            }

            var u = c[0];
            var v = c[1];
            if (u < 0 || u >= n || v < 0 || v >= n) {
                continue;
            }

            adj[u].Add((v, 1)); // 1 represents an original edge u -> v
            adj[v].Add((u, 0)); // 0 represents a reversed edge v -> u
        }

        var seen = new bool[n];
        var queue = new Queue<int>();
        var revs = 0;

        queue.Enqueue(0);
        seen[0] = true;

        while (queue.Count > 0) {
            var node = queue.Dequeue();

            foreach (var (neighbor, direction) in adj[node]) {
                if (!seen[neighbor]) {
                    seen[neighbor] = true;
                    revs += direction; // Add 1 if it's an original edge (node -> neighbor)
                    queue.Enqueue(neighbor);
                }
            }
        }

        return revs;
    }
}