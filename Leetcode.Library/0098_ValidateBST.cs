using Leetcode.Common;

namespace Leetcode {
    public abstract class ValidateBST {
        public static bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }

            var stack = new Stack<(TreeNode node, long lower, long upper)>();

            stack.Push((root, long.MinValue, long.MaxValue));

            while (stack.Count > 0) {
                var (node, lower, upper) = stack.Pop();

                long val = node.val;

                if (val <= lower || val >= upper) {
                    return false;
                }

                if (node.right != null) {
                    stack.Push((node.right, val, upper));
                }

                if (node.left != null) {
                    stack.Push((node.left, lower, val));
                }
            }

            return true;
        }
    }
}