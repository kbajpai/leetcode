using Leetcode.Common;

namespace Leetcode.DataStructures {
    public abstract class Trees {
        /// <summary>
        /// Calculates the maximum depth (height) of a binary tree.
        /// </summary>
        /// <param name="root">The root node of the binary tree.</param>
        /// <returns>
        /// The maximum depth of the tree, defined as the number of nodes along 
        /// the longest path from the root node down to the farthest leaf node.
        /// Returns 0 if the tree is empty.
        /// </returns>
        /// <remarks>
        /// Time Complexity: O(n) where n is the number of nodes in the tree.
        /// Space Complexity: O(h) where h is the height of the tree (recursion stack).
        /// </remarks>
        public static int MaxDepth(TreeNode? root) {
            if (root == null) {
                return 0;
            }

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}