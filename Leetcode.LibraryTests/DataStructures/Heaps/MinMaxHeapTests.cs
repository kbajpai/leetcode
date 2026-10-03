using Leetcode.Common;
using Leetcode.DataStructures.Heaps;
using Xunit;

namespace LeetcodeTests.DataStructures.Heaps {
    public class MinMaxHeapTests {
        #region IsCompleteBinaryTree Tests

        [Fact]
        public void IsCompleteBinaryTree_NullRoot_ReturnsTrue() {
            TreeNode? root = null;
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_SingleNode_ReturnsTrue() {
            var root = new TreeNode(1);
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_CompleteTreeWithTwoNodes_ReturnsTrue() {
            //    1
            //   /
            //  2
            var root = new TreeNode(1, new TreeNode(2), null);
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_CompleteTreeWithThreeNodes_ReturnsTrue() {
            //    1
            //   / \
            //  2   3
            var root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_CompleteFullTree_ReturnsTrue() {
            //       1
            //      / \
            //     2   3
            //    / \
            //   4   5
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3));
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_CompleteTreeSevenNodes_ReturnsTrue() {
            //       1
            //      / \
            //     2   3
            //    / \ / \
            //   4  5 6  7
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, new TreeNode(6), new TreeNode(7)));
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_IncompleteTreeMissingLeftChild_ReturnsFalse() {
            //    1
            //     \
            //      2
            var root = new TreeNode(1, null, new TreeNode(2));
            Assert.False(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_IncompleteTreeGapInLevel_ReturnsFalse() {
            //       1
            //      / \
            //     2   3
            //    /     \
            //   4       5
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), null),
                new TreeNode(3, null, new TreeNode(5)));
            Assert.False(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_IncompleteTreeSkippedNode_ReturnsFalse() {
            //       1
            //      / \
            //     2   3
            //        / \
            //       4   5
            var root = new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3, new TreeNode(4), new TreeNode(5)));
            Assert.False(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        [Fact]
        public void IsCompleteBinaryTree_IncompleteTreeOnlyRightChild_ReturnsFalse() {
            //       1
            //      / \
            //     2   3
            //    / \   \
            //   4   5   6
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, null, new TreeNode(6)));
            Assert.False(MinMaxHeap.IsCompleteBinaryTree(root));
        }

        #endregion

        #region IsMaxHeap Tests

        [Fact]
        public void IsMaxHeap_NullRoot_ReturnsTrue() {
            TreeNode? root = null;
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_SingleNode_ReturnsTrue() {
            var root = new TreeNode(10);
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_ValidMaxHeapTwoNodes_ReturnsTrue() {
            //   10
            //   /
            //  5
            var root = new TreeNode(10, new TreeNode(5), null);
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_ValidMaxHeapThreeNodes_ReturnsTrue() {
            //   10
            //   / \
            //  5   3
            var root = new TreeNode(10, new TreeNode(5), new TreeNode(3));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_ValidMaxHeapCompleteTree_ReturnsTrue() {
            //      10
            //     /  \
            //    9    8
            //   / \  /
            //  5  6 7
            var root = new TreeNode(10,
                new TreeNode(9, new TreeNode(5), new TreeNode(6)),
                new TreeNode(8, new TreeNode(7), null));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_ValidMaxHeapEqualValues_ReturnsTrue() {
            //   10
            //   / \
            //  10  10
            var root = new TreeNode(10, new TreeNode(10), new TreeNode(10));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_LeftChildGreaterThanParent_ReturnsFalse() {
            //   5
            //   /
            //  10
            var root = new TreeNode(5, new TreeNode(10), null);
            Assert.False(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_RightChildGreaterThanParent_ReturnsFalse() {
            //   5
            //    \
            //    10
            var root = new TreeNode(5, null, new TreeNode(10));
            Assert.False(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_ViolationInSubtree_ReturnsFalse() {
            //      10
            //     /  \
            //    9    8
            //   / \
            //  5  11
            var root = new TreeNode(10,
                new TreeNode(9, new TreeNode(5), new TreeNode(11)),
                new TreeNode(8));
            Assert.False(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_ViolationInRightSubtree_ReturnsFalse() {
            //      10
            //     /  \
            //    5    8
            //        / \
            //       7   9
            var root = new TreeNode(10,
                new TreeNode(5),
                new TreeNode(8, new TreeNode(7), new TreeNode(9)));
            Assert.False(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_MinHeapStructure_ReturnsFalse() {
            //      1
            //     / \
            //    5   3
            //   / \
            //  8   7
            var root = new TreeNode(1,
                new TreeNode(5, new TreeNode(8), new TreeNode(7)),
                new TreeNode(3));
            Assert.False(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_LargerValidMaxHeap_ReturnsTrue() {
            //        100
            //       /   \
            //      90    80
            //     / \   / \
            //    70 60 50 40
            //   /
            //  30
            var root = new TreeNode(100,
                new TreeNode(90,
                    new TreeNode(70, new TreeNode(30), null),
                    new TreeNode(60)),
                new TreeNode(80,
                    new TreeNode(50),
                    new TreeNode(40)));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_NegativeValues_ReturnsTrue() {
            //     -1
            //    /  \
            //  -5   -3
            var root = new TreeNode(-1, new TreeNode(-5), new TreeNode(-3));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsMaxHeap_MixedPositiveNegativeValues_ReturnsTrue() {
            //     10
            //    /  \
            //  -5    3
            var root = new TreeNode(10, new TreeNode(-5), new TreeNode(3));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        #endregion

        #region Combined Tests - Complete Binary Tree and Max Heap

        [Fact]
        public void IsCompleteAndMaxHeap_ValidHeap_BothReturnTrue() {
            //      10
            //     /  \
            //    9    8
            //   / \
            //  5   6
            var root = new TreeNode(10,
                new TreeNode(9, new TreeNode(5), new TreeNode(6)),
                new TreeNode(8));
            
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsCompleteAndMaxHeap_IncompleteButValidMaxHeap_OnlyMaxHeapReturnsTrue() {
            //      10
            //     /  \
            //    9    8
            //        / \
            //       7   6
            var root = new TreeNode(10,
                new TreeNode(9),
                new TreeNode(8, new TreeNode(7), new TreeNode(6)));
            
            Assert.False(MinMaxHeap.IsCompleteBinaryTree(root));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsCompleteAndMaxHeap_CompleteButInvalidMaxHeap_OnlyCompleteReturnsTrue() {
            //      5
            //     / \
            //    9   8
            var root = new TreeNode(5, new TreeNode(9), new TreeNode(8));
            
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
            Assert.False(MinMaxHeap.IsMaxHeap(root));
        }

        [Fact]
        public void IsCompleteAndMaxHeap_ZeroValues_BothReturnTrue() {
            //      0
            //     / \
            //    0   0
            var root = new TreeNode(0, new TreeNode(0), new TreeNode(0));
            
            Assert.True(MinMaxHeap.IsCompleteBinaryTree(root));
            Assert.True(MinMaxHeap.IsMaxHeap(root));
        }

        #endregion
    }
}
