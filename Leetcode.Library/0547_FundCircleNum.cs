namespace Leetcode;

public abstract class FindCircleNum {
    /// <summary>
    ///     Finds the number of provinces using DFS.
    ///     Time: O(n²), Space: O(n)
    /// </summary>
    public static int RunFindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        if (n <= 1) {
            return n;
        }

        // Validate matrix shape
        for (var i = 0; i < n; i++) {
            if (isConnected[i] == null || isConnected[i].Length != n) {
                throw new ArgumentException("isConnected must be a non-null n x n matrix", nameof(isConnected));
            }
        }

        var visited = new bool[n];
        var provinces = 0;

        for (var i = 0; i < n; i++) {
            if (!visited[i]) {
                provinces++;
                DFS(i);
            }
        }

        return provinces;

        // Iterative DFS using a stack to avoid recursion overhead and deep call stacks
        void DFS(int start) {
            var stack = new Stack<int>();
            stack.Push(start);
            visited[start] = true;

            while (stack.Count > 0) {
                var city = stack.Pop();
                var row = isConnected[city];

                for (var j = 0; j < n; j++) {
                    if (row[j] == 1 && !visited[j]) {
                        visited[j] = true;
                        stack.Push(j);
                    }
                }
            }
        }
    }
}