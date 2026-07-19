using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class RemoveBoxesTests {
    [Fact]
    public void RunRemoveBoxes_ExampleInput_ReturnsTwentyThree() {
        // Arrange
        var boxes = new[] { 1, 3, 2, 2, 2, 3, 4, 3, 1 };

        // Act
        var result = RemoveBoxes.RunRemoveBoxes(boxes);

        // Assert
        Assert.Equal(23, result);
    }

    [Fact]
    public void RunRemoveBoxes_SingleBox_ReturnsOne() {
        // Arrange
        var boxes = new[] { 7 };

        // Act
        var result = RemoveBoxes.RunRemoveBoxes(boxes);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunRemoveBoxes_AllSameColor_ReturnsSquareOfCount() {
        // Arrange
        var boxes = new[] { 5, 5, 5 };

        // Act
        var result = RemoveBoxes.RunRemoveBoxes(boxes);

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void RunRemoveBoxes_AllDistinct_ReturnsThree() {
        // Arrange
        var boxes = new[] { 1, 2, 3 };

        // Act
        var result = RemoveBoxes.RunRemoveBoxes(boxes);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void RunRemoveBoxes_SeparatedMatchingBoxes_ReturnsFive() {
        // Arrange
        var boxes = new[] { 1, 2, 1 };

        // Act
        var result = RemoveBoxes.RunRemoveBoxes(boxes);

        // Assert
        Assert.Equal(5, result);
    }
}
