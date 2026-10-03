using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class ThreeSumTests {
    [Fact]
    public void FindThreeSum_Duplicates_ReturnsUniqueTriplets() {
        // Arrange
        int[] nums = [-2, 0, 0, 2, 2];

        // Act
        var result = ThreeSum.FindThreeSum(nums);

        // Assert
        var expected = new List<IList<int>> {
            new List<int> { -2, 0, 2 }
        };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindThreeSum_EmptyArray_ReturnsEmptyList() {
        // Arrange
        int[] nums = [];

        // Act
        var result = ThreeSum.FindThreeSum(nums);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindThreeSum_LessThanThreeElements_ReturnsEmptyList() {
        // Arrange
        int[] nums = [1, -1];

        // Act
        var result = ThreeSum.FindThreeSum(nums);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindThreeSum_MultipleTriplets_ReturnsCorrectResult() {
        // Arrange
        int[] nums = [-1, 0, 1, 2, -1, -4];

        // Act
        var result = ThreeSum.FindThreeSum(nums);

        // Assert
        var expected = new List<IList<int>> {
            new List<int> { -1, -1, 2 },
            new List<int> { -1, 0, 1 }
        };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindThreeSum_NoTriplets_ReturnsEmptyList() {
        // Arrange
        int[] nums = [1, 2, 3, 4];

        // Act
        var result = ThreeSum.FindThreeSum(nums);

        // Assert
        Assert.Empty(result);
    }
}