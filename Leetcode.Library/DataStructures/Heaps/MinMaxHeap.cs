using Leetcode.Common;

namespace Leetcode.DataStructures.Heaps {
    public abstract class MinMaxHeap {
        public static bool IsCompleteBinaryTree(TreeNode? root) {
            if (root == null) {
                return true;
            }

            var queue = new Queue<TreeNode?>();
            queue.Enqueue(root);

            while (queue.Count > 0) {
                var node = queue.Dequeue();

                if (node == null) {
                    // Once we hit a null, all remaining nodes in queue must be null
                    while (queue.Count > 0) {
                        if (queue.Dequeue() != null) {
                            return false;
                        }
                    }

                    break;
                }

                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return true;
        }

        public static bool IsMaxHeap(TreeNode? root) {
            // Base case: null nodes are valid
            if (root == null) {
                return true;
            }

            // Check max heap property: parent >= children
            if (root.left != null && root.left.val > root.val) {
                return false;
            }

            if (root.right != null && root.right.val > root.val) {
                return false;
            }

            // Recursively validate subtrees
            return IsMaxHeap(root.left) && IsMaxHeap(root.right);
        }
    }
}