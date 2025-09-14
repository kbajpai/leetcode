using Leetcode;
using Leetcode.Common;
using Xunit;

namespace LeetcodeTests;

public class LevelOrderTests {
    [Fact]
    public void RunLevelOrder_CompleteBinaryTree_ReturnsCorrectLevels() {
        // Arrange
        // Tree:      1
        //          /   \
        //         2     3
        //        / \   / \
        //       4  5  6  7
        var root = BuildTree([1, 2, 3, 4, 5, 6, 7]);

        // Act
        var result = LevelOrder.RunLevelOrder(root);

        // Assert
        Assert.Equal([[1], [2, 3], [4, 5, 6, 7]], result.Select(l => l.ToArray()).ToArray());
    }

    [Fact]
    public void RunLevelOrder_NullRoot_ReturnsEmptyList() {
        // Act
        var result = LevelOrder.RunLevelOrder(null);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void RunLevelOrder_OnlyLeftChildren_ReturnsCorrectLevels() {
        // Arrange
        // Tree: 1 -> 2 -> 3 -> 4
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3,
                    new TreeNode(4)
                )
            )
        );

        // Act
        var result = LevelOrder.RunLevelOrder(root);

        // Assert
        Assert.Equal([[1], [2], [3], [4]], result.Select(l => l.ToArray()).ToArray());
    }

    [Fact]
    public void RunLevelOrder_OnlyRightChildren_ReturnsCorrectLevels() {
        // Arrange
        // Tree: 1 -> 2 -> 3 -> 4 (all right children)
        var root = new TreeNode(1,
            right: new TreeNode(2,
                right: new TreeNode(3,
                    right: new TreeNode(4)
                )
            )
        );

        // Act
        var result = LevelOrder.RunLevelOrder(root);

        // Assert
        Assert.Equal([[1], [2], [3], [4]], result.Select(l => l.ToArray()).ToArray());
    }

    [Fact]
    public void RunLevelOrder_SingleNode_ReturnsSingleLevel() {
        // Arrange
        var root = new TreeNode(1);

        // Act
        var result = LevelOrder.RunLevelOrder(root);

        // Assert
        Assert.Single(result);
        Assert.Equal([1], result[0]);
    }

    [Fact]
    public void RunLevelOrder_UnbalancedTree_ReturnsCorrectLevels() {
        // Arrange
        // Tree:    1
        //         /
        //        2
        //         \
        //          3
        //         /
        //        4
        var root = new TreeNode(1,
            new TreeNode(2,
                right: new TreeNode(3,
                    new TreeNode(4)
                )
            )
        );

        // Act
        var result = LevelOrder.RunLevelOrder(root);

        // Assert
        Assert.Equal([[1], [2], [3], [4]], result.Select(l => l.ToArray()).ToArray());
    }

    // Plan (pseudocode):
    // 1. If values is empty or first element is null, return null.
    // 2. Create an array `nodes` of TreeNode? with the same length.
    // 3. Fill `nodes[i]` with a TreeNode containing the value when values[i] has a value.
    //    At this point children are not set.
    // 4. Build the tree bottom-up: iterate i from last index down to 0.
    //    For each non-null `nodes[i]`, compute left index = 2*i+1 and right index = 2*i+2.
    //    Use `nodes[leftIndex]` and `nodes[rightIndex]` as the left/right children (may be null).
    //    Create a new TreeNode with the same val and the computed children and assign back to nodes[i].
    // 5. Return nodes[0] as the root.
    private static TreeNode? BuildTree(int?[] values) {
        if (values.Length == 0 || values[0] == null) return null;
        var n = values.Length;
        var nodes = new TreeNode?[n];
        // Create nodes with values only
        for (var i = 0; i < n; i++) {
            if (values[i].HasValue)
                nodes[i] = new TreeNode(values[i]!.Value);
        }

        // Assign children bottom-up so children references are already constructed
        for (var i = n - 1; i >= 0; i--) {
            if (nodes[i] == null) continue;
            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;
            var left = leftIndex < n ? nodes[leftIndex] : null;
            var right = rightIndex < n ? nodes[rightIndex] : null;
            nodes[i] = new TreeNode(nodes[i]!.val, left, right);
        }

        return nodes[0];
    }
}