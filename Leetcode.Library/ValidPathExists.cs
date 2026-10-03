namespace Leetcode {
    /// <summary>
    ///     Provides functionality to determine if a valid path exists between two nodes in an undirected graph.
    ///     Uses optimized graph traversal algorithms for efficient path finding.
    /// </summary>
    public abstract class ValidPathExists {
        /// <summary>
        ///     Determines if there exists a valid path from source to destination in an undirected graph.
        /// </summary>
        /// <param name="n">The number of nodes in the graph (nodes are labeled from 0 to n-1)</param>
        /// <param name="edges">Array of edges where each edge is represented as [node1, node2]</param>
        /// <param name="source">The starting node for path search</param>
        /// <param name="destination">The target node to reach</param>
        /// <returns>True if a path exists from source to destination, false otherwise</returns>
        /// <remarks>
        ///     Time Complexity: O(V + E) where V is number of vertices and E is number of edges
        ///     Space Complexity: O(V + E) for adjacency list and visited tracking
        ///     Uses iterative DFS to avoid stack overflow on deep graphs
        /// </remarks>
        public static bool ValidPath(int n, int[][] edges, int source, int destination) {
            // Edge case: single node or no nodes
            if (n <= 1) {
                return true;
            }

            // Early return if source equals destination
            if (source == destination) {
                return true;
            }

            // Edge case: no edges but different source and destination
            if (edges.Length == 0) {
                return false;
            }

            // Build adjacency list using arrays for better performance
            var adjacencyList = BuildAdjacencyList(n, edges);

            // Use iterative DFS to avoid recursion overhead and potential stack overflow
            return HasPathIterativeDFS(adjacencyList, source, destination, n);
        }

        /// <summary>
        ///     Builds an adjacency list representation of the graph using arrays for optimal performance.
        /// </summary>
        /// <param name="n">Number of nodes in the graph</param>
        /// <param name="edges">Array of edges</param>
        /// <returns>Adjacency list as array of arrays</returns>
        private static int[][] BuildAdjacencyList(int n, int[][] edges) {
            // First pass: count degrees for each node
            var degree = new int[n];
            foreach (var edge in edges) {
                degree[edge[0]]++;
                degree[edge[1]]++;
            }

            // Initialize adjacency arrays based on degrees
            var adjacencyList = new int[n][];
            for (var i = 0; i < n; i++) {
                adjacencyList[i] = degree[i] == 0 ? Array.Empty<int>() : new int[degree[i]];
            }

            // Second pass: populate adjacency lists
            Array.Fill(degree, 0); // Reuse degree array as index tracker
            foreach (var edge in edges) {
                var nodeA = edge[0];
                var nodeB = edge[1];

                adjacencyList[nodeA][degree[nodeA]++] = nodeB;
                adjacencyList[nodeB][degree[nodeB]++] = nodeA;
            }

            return adjacencyList;
        }

        /// <summary>
        ///     Performs iterative depth-first search to find path between source and destination.
        /// </summary>
        /// <param name="adjacencyList">Graph representation as adjacency list</param>
        /// <param name="source">Starting node</param>
        /// <param name="destination">Target node</param>
        /// <param name="n">Total number of nodes</param>
        /// <returns>True if path exists, false otherwise</returns>
        private static bool HasPathIterativeDFS(int[][] adjacencyList, int source, int destination, int n) {
            var visited = new bool[n];
            var stack = new Stack<int>();

            visited[source] = true;
            stack.Push(source);

            while (stack.Count > 0) {
                var currentNode = stack.Pop();

                // Early termination: found destination
                if (currentNode == destination) {
                    return true;
                }

                // Explore all unvisited neighbors
                var neighbors = adjacencyList[currentNode];
                for (var i = 0; i < neighbors.Length; i++) {
                    var neighbor = neighbors[i];
                    if (!visited[neighbor]) {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                    }
                }
            }

            return false;
        }
    }
}