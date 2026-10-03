namespace Leetcode.Common;

public sealed class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
    public readonly int val = val;
    public readonly TreeNode? left = left;
    public readonly TreeNode? right = right;
}