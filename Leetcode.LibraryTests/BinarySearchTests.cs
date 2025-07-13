using Leetcode.CodeTemplates;
using Xunit;

namespace LeetcodeTests;

public class BinarySearchTests {
    [Theory]
    [InlineData(new int[] { }, 1, -1)]
    [InlineData(new[] { 10, 20, 30, 40 }, 40, 3)]
    [InlineData(new[] { 2, 4, 6, 8 }, 2, 0)]
    [InlineData(new[] { 1, 3, 5, 7, 9 }, 5, 2)]
    [InlineData(new[] { 42 }, 42, 0)]
    [InlineData(new[] { 100 }, 50, -1)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 6, -1)]
    public void RunBinarySearch_VariousCases_ReturnsExpectedIndex(int[] nums, int target, int expected) {
        Assert.Equal(expected, BinarySearch.RunBinarySearch(nums, target));
    }
}