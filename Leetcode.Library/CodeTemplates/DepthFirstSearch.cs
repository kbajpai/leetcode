using Leetcode.Common;

namespace Leetcode.CodeTemplates;

public abstract class DepthFirstSearch {
    /// <summary>
    ///     Performs an iterative depth-first traversal (preorder) of a binary tree using a stack.
    /// </summary>
    /// <param name="root">
    ///     The root <see cref="TreeNode" /> of the binary tree to traverse. If <c>null</c>, returns an empty list.
    /// </param>
    /// <returns>
    ///     An <see cref="IList{T}" /> containing the values of the nodes visited in preorder.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         Time Complexity: O(n), where n is the number of nodes in the tree.
    ///         Each node is visited exactly once.
    ///     </para>
    ///     <para>
    ///         Space Complexity: O(h), where h is the height of the tree.
    ///         The stack holds at most h nodes at any time.
    ///         The result list uses O(n) space.
    ///     </para>
    /// </remarks>
    public static IList<int> Traverse(TreeNode? root) {
        if (root == null) return Array.Empty<int>();

        // Estimate capacity: avoid resizing for small trees
        var result = new List<int>(32);
        var stack = new Stack<TreeNode>(32);
        stack.Push(root);

        while (stack.Count > 0) {
            var node = stack.Pop();
            result.Add(node.val);

            // Push right first so left is processed first
            var right = node.right;
            var left = node.left;

            if (right != null)
                stack.Push(right);

            if (left != null)
                stack.Push(left);
        }

        return result;
    }
}