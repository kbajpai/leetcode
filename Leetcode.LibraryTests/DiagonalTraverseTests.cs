using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class DiagonalTraverseTests {
    [Fact]
    public void FindDiagonalOrder_RectangularMatrix_MoreCols_ReturnsCorrectOrder() {
        // Arrange
        var mat = new[] {
            new[] { 1, 2, 3, 4 },
            [5, 6, 7, 8]
        };
        var solver = new DiagonalTraverse();

        // Act
        var result = solver.FindDiagonalOrder(mat);

        // Assert
        Assert.Equal([1, 2, 5, 6, 3, 4, 7, 8], result);
    }

    [Fact]
    public void FindDiagonalOrder_RectangularMatrix_MoreRows_ReturnsCorrectOrder() {
        // Arrange
        var mat = new[] {
            new[] { 1, 2 },
            [3, 4],
            [5, 6]
        };
        var solver = new DiagonalTraverse();

        // Act
        var result = solver.FindDiagonalOrder(mat);

        // Assert
        Assert.Equal([1, 2, 3, 5, 4, 6], result);
    }

    [Fact]
    public void FindDiagonalOrder_SingleElement_ReturnsElement() {
        // Arrange
        var mat = new[] { new[] { 42 } };
        var solver = new DiagonalTraverse();

        // Act
        var result = solver.FindDiagonalOrder(mat);

        // Assert
        Assert.Equal([42], result);
    }

    [Fact]
    public void FindDiagonalOrder_SquareMatrix_ReturnsCorrectOrder() {
        // Arrange
        var mat = new[] {
            new[] { 1, 2, 3 },
            [4, 5, 6],
            [7, 8, 9]
        };
        var solver = new DiagonalTraverse();

        // Act
        var result = solver.FindDiagonalOrder(mat);

        // Assert
        Assert.Equal([1, 2, 4, 7, 5, 3, 6, 8, 9], result);
    }

    [Fact]
    public void FindDiagonalOrder_TwoByTwo_ReturnsCorrectOrder() {
        // Arrange
        var mat = new[] {
            new[] { 1, 2 },
            [3, 4]
        };
        var solver = new DiagonalTraverse();

        // Act
        var result = solver.FindDiagonalOrder(mat);

        // Assert
        Assert.Equal([1, 2, 3, 4], result);
    }
}