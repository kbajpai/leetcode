using Leetcode;
using Leetcode.Common;
using Xunit;

namespace LeetcodeTests {
    public class ValidateBSTTests {
        [Fact]
        public void NullRoot_IsValid() {
            TreeNode root = null;
            Assert.True(ValidateBST.IsValidBST(root));
        }

        [Fact]
        public void SingleNode_IsValid() {
            var root = new TreeNode(1);
            Assert.True(ValidateBST.IsValidBST(root));
        }

        [Fact]
        public void ValidBST_ReturnsTrue() {
            //    2
            //   / \
            //  1   3
            var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            Assert.True(ValidateBST.IsValidBST(root));
        }

        [Fact]
        public void InvalidBST_ReturnsFalse() {
            //    5
            //   / \
            //  1   4
            //     / \
            //    3   6
            var root = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
            Assert.False(ValidateBST.IsValidBST(root));
        }

        [Fact]
        public void LeftChildGreaterThanParent_IsInvalid() {
            var root = new TreeNode(10, new TreeNode(15), null);
            Assert.False(ValidateBST.IsValidBST(root));
        }

        [Fact]
        public void RightChildLessThanParent_IsInvalid() {
            var root = new TreeNode(10, null, new TreeNode(5));
            Assert.False(ValidateBST.IsValidBST(root));
        }

        [Fact]
        public void LargerTreeValidBST_ReturnsTrue() {
            //      8
            //     / \
            //    4   12
            //   / \  / \
            //  2  6 10 14
            var root = new TreeNode(8,
                new TreeNode(4, new TreeNode(2), new TreeNode(6)),
                new TreeNode(12, new TreeNode(10), new TreeNode(14)));
            Assert.True(ValidateBST.IsValidBST(root));
        }
    }
}
