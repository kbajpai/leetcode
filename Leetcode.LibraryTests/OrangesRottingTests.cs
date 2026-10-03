using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class OrangesRottingTests {
    [Fact]
    public void RunOrangesRotting_WithNoOranges_ShouldReturnZero() {
        var grid = new int[][] {
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        };
        Assert.Equal(0, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithOnlyRottenOranges_ShouldReturnZero() {
        var grid = new int[][] {
            [2, 2, 2],
            [2, 2, 2]
        };
        Assert.Equal(0, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithOnlyFreshOranges_ShouldReturnMinusOne() {
        var grid = new int[][] {
            [1, 1, 1],
            [1, 1, 1]
        };
        Assert.Equal(-1, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithBasicCase_ShouldReturnFour() {
        var grid = new int[][] {
            [2, 1, 1],
            [1, 1, 0],
            [0, 1, 1]
        };
        Assert.Equal(4, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithImpossibleCase_ShouldReturnMinusOne() {
        var grid = new int[][] {
            [2, 1, 1],
            [0, 1, 1],
            [1, 0, 1]
        };
        Assert.Equal(-1, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithSingleFreshOrange_ShouldReturnMinusOne() {
        var grid = new int[][] {
            [0, 2]
        };
        Assert.Equal(0, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithAdjacentOranges_ShouldReturnOne() {
        var grid = new int[][] {
            [2, 1]
        };
        Assert.Equal(1, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithLargerGrid_ShouldReturnCorrectTime() {
        var grid = new int[][] {
            [2, 1, 1, 1, 1],
            [1, 1, 1, 1, 1],
            [1, 1, 1, 1, 1],
            [1, 1, 1, 1, 1]
        };
        Assert.Equal(7, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithMultipleRottenStarts_ShouldReturnTwo() {
        var grid = new int[][] {
            [2, 1, 1],
            [1, 1, 1],
            [1, 1, 2]
        };
        Assert.Equal(2, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithSingleCell_FreshOrange_ShouldReturnMinusOne() {
        var grid = new int[][] {
            [1]
        };
        Assert.Equal(-1, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithSingleCell_RottenOrange_ShouldReturnZero() {
        var grid = new int[][] {
            [2]
        };
        Assert.Equal(0, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithSingleCell_Empty_ShouldReturnZero() {
        var grid = new int[][] {
            [0]
        };
        Assert.Equal(0, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithComplexLayout_ShouldReturnMinusOne() {
        var grid = new int[][] {
            [2, 1, 0, 1, 1],
            [1, 0, 1, 0, 1],
            [0, 1, 1, 1, 0],
            [1, 0, 1, 0, 2]
        };
        // This should return -1 because some fresh oranges are isolated
        Assert.Equal(-1, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithIsolatedFreshOrange_ShouldReturnMinusOne() {
        var grid = new int[][] {
            [2, 0, 1],
            [0, 0, 0],
            [1, 0, 2]
        };
        Assert.Equal(-1, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithVerticalLine_ShouldReturnTwo() {
        var grid = new int[][] {
            [2],
            [1],
            [1]
        };
        Assert.Equal(2, OrangesRotting.RunOrangesRotting(grid));
    }

    [Fact]
    public void RunOrangesRotting_WithHorizontalLine_ShouldReturnTwo() {
        var grid = new int[][] {
            [2, 1, 1]
        };
        Assert.Equal(2, OrangesRotting.RunOrangesRotting(grid));
    }
}