using Leetcode.CodeTemplates;
using Leetcode.Common;
using Xunit;

namespace LeetcodeTests;

public class BreadthFirstSearchTests {
    [Fact]
    public void Traverse_ReturnsEmpty_ForNullRoot() {
        var result = BreadthFirstSearch.Traverse(null);
        Assert.Empty(result);
    }

    [Fact]
    public void Traverse_ReturnsLevelOrder_ForLeftSkewedTree() {
        // Tree: 1 -> 2 -> 3 -> 4
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3,
                    new TreeNode(4))));
        var result = BreadthFirstSearch.Traverse(root);
        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void Traverse_ReturnsLevelOrder_ForRightSkewedTree() {
        // Tree: 1 -> 2 -> 3 -> 4 (all right children)
        var root = new TreeNode(1,
            null,
            new TreeNode(2,
                null,
                new TreeNode(3,
                    null,
                    new TreeNode(4))));
        var result = BreadthFirstSearch.Traverse(root);
        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void Traverse_ReturnsLevelOrder_ForTypicalTree() {
        // Tree:    1
        //         / \
        //        2   3
        //       /   / \
        //      4   5   6
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(4)),
            new TreeNode(3,
                new TreeNode(5),
                new TreeNode(6)));

        var result = BreadthFirstSearch.Traverse(root);
        Assert.Equal([1, 2, 3, 4, 5, 6], result);
    }

    [Fact]
    public void Traverse_ReturnsSingleNode_ForSingleNodeTree() {
        var root = new TreeNode(42);
        var result = BreadthFirstSearch.Traverse(root);
        Assert.Equal([42], result);
    }
}