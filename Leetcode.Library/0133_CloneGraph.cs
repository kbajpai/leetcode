using System.Runtime.CompilerServices;

namespace Leetcode {
    /// <summary>
    ///     LeetCode Problem 133: Clone Graph
    ///     Given a reference of a node in a connected undirected graph, returns a deep copy (clone) of the graph.
    ///     Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.
    ///     Algorithm: Depth-First Search (DFS) with memoization
    ///     Time Complexity: O(V + E) where V is vertices and E is edges
    ///     Space Complexity: O(V) for the node mapping and recursion stack
    /// </summary>
    public abstract class CloneGraph {
        /// <summary>
        ///     Maps original nodes to their cloned counterparts to prevent infinite loops
        ///     and ensure each node is cloned exactly once.
        /// </summary>
        private readonly Dictionary<Node, Node> _nodeMap = new();

        /// <summary>
        ///     Creates a deep copy of the given graph starting from the specified node.
        /// </summary>
        /// <param name="node">The starting node of the graph to clone. Can be null.</param>
        /// <returns>
        ///     A cloned version of the graph starting from the equivalent of the input node,
        ///     or null if the input is null.
        /// </returns>
        /// <remarks>
        ///     This method can be called multiple times on the same instance.
        ///     The internal node mapping is cleared before each operation to ensure independence.
        /// </remarks>
        public Node? RunCloneGraph(Node? node) {
            if (node == null) {
                return null;
            }

            _nodeMap.Clear(); // Reset mapping for reuse - ensures each call is independent
            return DFS(node);
        }

        /// <summary>
        ///     Performs depth-first search to recursively clone nodes and their connections.
        ///     Uses memoization to avoid infinite loops in cyclic graphs and ensure each node
        ///     is cloned exactly once.
        /// </summary>
        /// <param name="node">The current node to clone (guaranteed to be non-null)</param>
        /// <returns>The cloned version of the input node</returns>
        /// <remarks>
        ///     The method is marked with AggressiveInlining for performance optimization
        ///     since it's called recursively and benefits from being inlined.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Node DFS(Node node) {
            // Check if we've already cloned this node (handles cycles and prevents duplication)
            if (_nodeMap.TryGetValue(node, out var clonedNode)) {
                return clonedNode;
            }

            // Create a new node with the same value
            var cpNode = new Node(node.Val);

            // Immediately add to map to handle self-references and cycles
            _nodeMap[node] = cpNode;

            // Optimize memory allocation for neighbors list
            if (node.Neighbors.Count > 0) {
                // Pre-allocate capacity if the backing collection is a List<T>
                // This reduces memory reallocations during neighbor addition
                if (cpNode.Neighbors is List<Node> list) {
                    list.Capacity = node.Neighbors.Count;
                }

                // Recursively clone all neighbors and add them to the cloned node
                foreach (var neighbor in node.Neighbors) {
                    cpNode.Neighbors.Add(DFS(neighbor));
                }
            }

            return cpNode;
        }
    }

    /// <summary>
    ///     Represents a node in an undirected graph.
    ///     Each node contains a value and a list of neighboring nodes.
    /// </summary>
    /// <remarks>
    ///     This class is sealed for performance optimizations and uses reference equality
    ///     for efficient dictionary operations during the cloning process.
    /// </remarks>
    public sealed class Node {
        /// <summary>
        ///     The integer value stored in this node.
        ///     This value is immutable once the node is created.
        /// </summary>
        public readonly int Val;

        /// <summary>
        ///     The list of neighboring nodes connected to this node.
        ///     This collection can be modified to add or remove connections.
        /// </summary>
        public readonly IList<Node> Neighbors;

        /// <summary>
        ///     Initializes a new node with value 0 and an empty neighbors list.
        /// </summary>
        public Node() : this(0) { }

        /// <summary>
        ///     Initializes a new node with the specified value and an empty neighbors list.
        /// </summary>
        /// <param name="val">The value to store in this node</param>
        public Node(int val) {
            Val = val;
            Neighbors = new List<Node>();
        }

        /// <summary>
        ///     Initializes a new node with the specified value and neighbors list.
        /// </summary>
        /// <param name="val">The value to store in this node</param>
        /// <param name="neighbors">The initial list of neighbors. If null, an empty list is created.</param>
        public Node(int val, List<Node>? neighbors) {
            Val = val;
            Neighbors = neighbors ?? new List<Node>();
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current node.
        ///     Uses reference equality for optimal performance in dictionary operations.
        /// </summary>
        /// <param name="obj">The object to compare with the current node</param>
        /// <returns>true if the specified object is the same instance as this node; otherwise, false</returns>
        /// <remarks>
        ///     Reference equality is used instead of value equality because each node instance
        ///     represents a unique vertex in the graph, even if they have the same value.
        ///     This optimization improves dictionary lookup performance during cloning.
        /// </remarks>
        public override bool Equals(object? obj) => ReferenceEquals(this, obj);

        /// <summary>
        ///     Serves as the hash function for this node.
        ///     Uses the runtime-provided object hash code for optimal performance.
        /// </summary>
        /// <returns>A hash code for the current node based on its object reference</returns>
        /// <remarks>
        ///     RuntimeHelpers.GetHashCode provides a hash based on object identity rather than
        ///     object state, which is consistent with the reference equality implementation
        ///     and provides better performance for dictionary operations.
        /// </remarks>
        public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);
    }
}