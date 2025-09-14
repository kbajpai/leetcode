using Leetcode.Common;

namespace Leetcode;

/// <summary>
///     Provides utilities for performing a level-order (breadth-first) traversal on a binary tree.
/// </summary>
/// <remarks>
///     This abstract utility class exposes static methods related to level-order traversal.
///     It operates on <see cref="TreeNode" /> instances defined in the <c>Leetcode.Common</c> namespace.
/// </remarks>
public abstract class LevelOrder {
    /// <summary>
    ///     Performs a level-order (breadth-first) traversal of the binary tree rooted at <paramref name="root" />.
    /// </summary>
    /// <param name="root">
    ///     The root node of the binary tree to traverse. If <c>null</c>, the method returns an empty list.
    /// </param>
    /// <returns>
    ///     A list of levels, where each level is represented as an <see cref="IList{T}" /> of <c>int</c> node values.
    ///     The outer list is ordered from the tree's top level (root) to the bottommost level.
    /// </returns>
    /// <remarks>
    ///     Implementation details:
    ///     - Uses a queue to perform breadth-first traversal.
    ///     - For each level, the current queue size determines the number of nodes at that level.
    ///     - Time complexity: O(n), where n is the number of nodes in the tree.
    ///     - Space complexity: O(n), due to the queue and the output list storing node values.
    /// </remarks>
    public static IList<IList<int>> RunLevelOrder(TreeNode? root) {
        if (root == null) return new List<IList<int>>();

        var l = new List<IList<int>>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            var levelSize = q.Count;
            var level = new List<int>(levelSize);
            for (var i = 0; i < levelSize; i++) {
                var node = q.Dequeue();
                level.Add(node.val);
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }

            l.Add(level);
        }

        return l;
    }
}