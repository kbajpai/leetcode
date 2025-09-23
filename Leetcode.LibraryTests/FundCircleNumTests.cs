using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class FindCircleNumTests {
    [Fact]
    public void FindCircleNum_FourCitiesAllSeparate_ReturnsFour() {
        // Arrange
        var isConnected = new int[][] {
            [1, 0, 0, 0],
            [0, 1, 0, 0],
            [0, 0, 1, 0],
            [0, 0, 0, 1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void FindCircleNum_FourCitiesComplexConnections_ReturnsCorrectCount() {
        // Arrange
        var isConnected = new int[][] {
            [1, 0, 0, 1],
            [0, 1, 1, 0],
            [0, 1, 1, 0],
            [1, 0, 0, 1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void FindCircleNum_SingleCity_ReturnsOne() {
        // Arrange
        var isConnected = new int[][] {
            [1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void FindCircleNum_ThreeCitiesAllConnected_ReturnsOne() {
        // Arrange
        var isConnected = new int[][] {
            [1, 1, 1],
            [1, 1, 1],
            [1, 1, 1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void FindCircleNum_ThreeCitiesOneProvince_ReturnsOne() {
        // Arrange
        var isConnected = new int[][] {
            [1, 1, 0],
            [1, 1, 0],
            [0, 0, 1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void FindCircleNum_TwoCitiesConnected_ReturnsOne() {
        // Arrange
        var isConnected = new int[][] {
            [1, 1],
            [1, 1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void FindCircleNum_TwoCitiesNotConnected_ReturnsTwo() {
        // Arrange
        var isConnected = new int[][] {
            [1, 0],
            [0, 1]
        };

        // Act
        var result = FindCircleNum.RunFindCircleNum(isConnected);

        // Assert
        Assert.Equal(2, result);
    }
}