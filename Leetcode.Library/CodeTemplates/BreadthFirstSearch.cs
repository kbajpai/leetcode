using Leetcode.Common;

namespace Leetcode.CodeTemplates;

public abstract class BreadthFirstSearch {
    /// <summary>
    ///     Performs an iterative breadth-first (level order) traversal of a binary tree using a queue.
    /// </summary>
    /// <param name="root">
    ///     The root <see cref="TreeNode" /> of the binary tree to traverse. If <c>null</c>, returns an empty list.
    /// </param>
    /// <returns>
    ///     An <see cref="IList{T}" /> containing the values of the nodes visited in level order.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         Time Complexity: O(n), where n is the number of nodes in the tree.
    ///         Each node is visited exactly once.
    ///     </para>
    ///     <para>
    ///         Space Complexity: O(w), where w is the maximum width of the tree.
    ///         The queue holds at most w nodes at any time.
    ///         The result list uses O(n) space.
    ///     </para>
    /// </remarks>
    public static IList<int> Traverse(TreeNode? root) {
        if (root == null) {
            return Array.Empty<int>();
        }

        var result = new List<int>(32);
        var queue = new Queue<TreeNode>(32);
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            result.Add(node.val);

            var left = node.left;
            var right = node.right;

            if (left != null) {
                queue.Enqueue(left);
            }

            if (right != null) {
                queue.Enqueue(right);
            }
        }

        return result;
    }
}