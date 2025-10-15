using Leetcode.Common;

namespace Leetcode {
    /// <summary>
    ///     LeetCode Problem 98: Validate Binary Search Tree
    ///     Determines if a binary tree is a valid Binary Search Tree (BST).
    ///     A valid BST is defined as follows:
    ///     - The left subtree of a node contains only nodes with keys less than the node's key.
    ///     - The right subtree of a node contains only nodes with keys greater than the node's key.
    ///     - Both the left and right subtrees must also be binary search trees.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <strong>Algorithm: Iterative Range Validation</strong>
    ///     </para>
    ///     <para>
    ///         Uses an iterative approach with a stack to validate BST properties by maintaining
    ///         valid ranges (lower and upper bounds) for each node. This approach avoids the pitfall
    ///         of only comparing parent-child relationships, which would miss cases like:
    ///         <code>
    ///     10
    ///    /  \
    ///   5    15
    ///       /  \
    ///      6   20
    /// </code>
    ///         where 6 is less than 10 (the root), violating BST properties despite being valid
    ///         relative to its parent (15).
    ///     </para>
    ///     <para>
    ///         <strong>Key Insights:</strong>
    ///     </para>
    ///     <list type="bullet">
    ///         <item>Each node must fall within a valid range based on its ancestors</item>
    ///         <item>Left children inherit the parent's lower bound and set the parent's value as their upper bound</item>
    ///         <item>Right children inherit the parent's upper bound and set the parent's value as their lower bound</item>
    ///         <item>
    ///             Uses <see cref="long" /> for bounds to handle edge cases with <see cref="int.MinValue" /> and
    ///             <see cref="int.MaxValue" />
    ///         </item>
    ///     </list>
    ///     <para>
    ///         <strong>Time Complexity:</strong> O(n) where n is the number of nodes
    ///     </para>
    ///     <para>
    ///         Each node is visited exactly once during the traversal.
    ///     </para>
    ///     <para>
    ///         <strong>Space Complexity:</strong> O(h) where h is the height of the tree
    ///     </para>
    ///     <para>
    ///         The stack stores at most h nodes in the worst case (skewed tree).
    ///         In a balanced tree, h = log(n). In a skewed tree, h = n.
    ///     </para>
    /// </remarks>
    public abstract class ValidateBST {
        /// <summary>
        ///     Validates whether a binary tree satisfies the Binary Search Tree property.
        /// </summary>
        /// <param name="root">The root node of the binary tree to validate. Can be null.</param>
        /// <returns>
        ///     <c>true</c> if the tree is a valid BST or if the tree is empty (null root);
        ///     <c>false</c> if any node violates the BST property.
        /// </returns>
        /// <example>
        ///     <para>
        ///         <strong>Example 1: Valid BST</strong>
        ///     </para>
        ///     <code>
        /// Input:
        ///     2
        ///    / \
        ///   1   3
        /// 
        /// Output: true
        /// Explanation: All nodes satisfy BST properties.
        /// </code>
        ///     <para>
        ///         <strong>Example 2: Invalid BST</strong>
        ///     </para>
        ///     <code>
        /// Input:
        ///     5
        ///    / \
        ///   1   4
        ///      / \
        ///     3   6
        /// 
        /// Output: false
        /// Explanation: Node 3 violates BST property (3 &lt; 5, but it's in right subtree of 5).
        /// </code>
        ///     <para>
        ///         <strong>Example 3: Edge Case with Boundary Values</strong>
        ///     </para>
        ///     <code>
        /// Input:
        ///     int.MaxValue
        ///    /
        ///   int.MinValue
        /// 
        /// Output: true
        /// Explanation: Handles extreme values correctly using long for bounds.
        /// </code>
        /// </example>
        /// <remarks>
        ///     <para>
        ///         <strong>Algorithm Steps:</strong>
        ///     </para>
        ///     <list type="number">
        ///         <item>Initialize stack with root node and initial bounds (long.MinValue, long.MaxValue)</item>
        ///         <item>
        ///             While stack is not empty:
        ///             <list type="bullet">
        ///                 <item>Pop a node with its valid range</item>
        ///                 <item>Check if node value is within the valid range (exclusive)</item>
        ///                 <item>If invalid, return false immediately</item>
        ///                 <item>Push right child with updated lower bound (current node value)</item>
        ///                 <item>Push left child with updated upper bound (current node value)</item>
        ///             </list>
        ///         </item>
        ///         <item>If all nodes pass validation, return true</item>
        ///     </list>
        ///     <para>
        ///         <strong>Why use long instead of int?</strong>
        ///     </para>
        ///     <para>
        ///         The bounds need to be exclusive. If a node has value <see cref="int.MinValue" /> or
        ///         <see cref="int.MaxValue" />, we need to represent bounds outside the int range.
        ///         Using <see cref="long" /> allows us to use <see cref="long.MinValue" /> and
        ///         <see cref="long.MaxValue" /> as initial bounds that will never conflict with any int value.
        ///     </para>
        /// </remarks>
        public static bool IsValidBST(TreeNode root) {
            // Base case: An empty tree is considered a valid BST
            if (root == null) {
                return true;
            }

            // Stack stores tuples of (node, lower_bound, upper_bound)
            // where lower_bound < node.val < upper_bound must be satisfied
            var stack = new Stack<(TreeNode node, long lower, long upper)>();

            // Initialize with root node and widest possible range
            stack.Push((root, long.MinValue, long.MaxValue));

            while (stack.Count > 0) {
                var (node, lower, upper) = stack.Pop();

                // Convert to long to compare with long bounds
                long val = node.val;

                // Validate BST property: lower < val < upper (exclusive bounds)
                if (val <= lower || val >= upper) {
                    return false;
                }

                // Process right subtree: all values must be > current node value
                // Inherit the upper bound, update lower bound to current value
                if (node.right != null) {
                    stack.Push((node.right, val, upper));
                }

                // Process left subtree: all values must be < current node value
                // Inherit the lower bound, update upper bound to current value
                if (node.left != null) {
                    stack.Push((node.left, lower, val));
                }
            }

            // All nodes passed validation
            return true;
        }
    }
}