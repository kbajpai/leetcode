using Leetcode.CodeTemplates;
using Xunit;

namespace LeetcodeTests;

public class TwoPointersTests {
    [Theory]
    [InlineData("Aba", false)]
    [InlineData("", true)]
    [InlineData("abba", true)]
    [InlineData("abc", false)]
    [InlineData("aba", true)]
    [InlineData("a", true)]
    [InlineData("a b a", true)]
    public void IsPalindrome_VariousInputs_ReturnsExpectedResult(string input, bool expected) {
        Assert.Equal(expected, TwoPointers.IsPalindrome(input));
    }

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 10, new[] { -1, -1 })]
    [InlineData(new[] { 1 }, 1, new[] { -1, -1 })]
    [InlineData(new[] { -3, 4, 3, 90 }, 0, new[] { 0, 2 })]
    public void TwoSum_VariousInputs_ReturnsExpectedIndices(int[] nums, int target, int[] expected) {
        Assert.Equal(expected, TwoPointers.TwoSum(nums, target));
    }
}