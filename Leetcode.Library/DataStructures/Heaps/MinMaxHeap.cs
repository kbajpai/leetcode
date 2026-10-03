using Leetcode.Common;

namespace Leetcode.DataStructures.Heaps {
    public abstract class MinMaxHeap {
        public static bool IsCompleteBinaryTree(TreeNode? root) {
            if (root == null) {
                return true;
            }

            var queue = new Queue<TreeNode?>();
            queue.Enqueue(root);
            var foundNull = false;

            while (queue.Count > 0) {
                var node = queue.Dequeue();

                if (node == null) {
                    foundNull = true;
                }
                else {
                    // If we've seen a null before and now see a non-null node, it's not complete
                    if (foundNull) {
                        return false;
                    }

                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }

            return true;
        }

        public static bool IsMaxHeap(TreeNode? root) {
            // Base case: null nodes are valid
            if (root == null) {
                return true;
            }

            // Check max heap property: parent >= children
            // Combined checks: validate left child exists and satisfies heap property
            if (root.left != null && (root.left.val > root.val || !IsMaxHeap(root.left))) {
                return false;
            }

            // Combined checks: validate right child exists and satisfies heap property
            if (root.right != null && (root.right.val > root.val || !IsMaxHeap(root.right))) {
                return false;
            }

            return true;
        }
    }
}