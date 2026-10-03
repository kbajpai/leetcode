using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class NumberOfIslandsTests {
    [Fact]
    public void RunNumberOfIslandsIterative_WithEmptyGrid_ShouldReturnZero() {
        var grid = Array.Empty<char[]>();
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslandsIterative(grid));
    }

    [Fact]
    public void RunNumberOfIslandsIterative_WithMultipleIslands_ShouldReturnThree() {
        var grid = GetGrid2();
        Assert.Equal(3, NumberOfIslands.RunNumberOfIslandsIterative(grid));
    }

    [Fact]
    public void RunNumberOfIslandsIterative_WithNoIslands_ShouldReturnZero() {
        var grid = new char[][] {
            ['0', '0', '0'],
            ['0', '0', '0']
        };
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslandsIterative(grid));
    }

    [Fact]
    public void RunNumberOfIslandsIterative_WithSingleIsland_ShouldReturnOne() {
        var grid = GetGrid1();
        Assert.Equal(1, NumberOfIslands.RunNumberOfIslandsIterative(grid));
    }

    [Fact]
    public void RunNumberOfIslandsRecursive_WithEmptyGrid_ShouldReturnZero() {
        var grid = Array.Empty<char[]>();
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslandsRecursive(grid));
    }

    [Fact]
    public void RunNumberOfIslandsRecursive_WithMultipleIslands_ShouldReturnThree() {
        var grid = GetGrid2();
        Assert.Equal(3, NumberOfIslands.RunNumberOfIslandsRecursive(grid));
    }

    [Fact]
    public void RunNumberOfIslandsRecursive_WithNoIslands_ShouldReturnZero() {
        var grid = new char[][] {
            ['0', '0', '0'],
            ['0', '0', '0']
        };
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslandsRecursive(grid));
    }

    [Fact]
    public void RunNumberOfIslandsRecursive_WithSingleIsland_ShouldReturnOne() {
        var grid = GetGrid1();
        Assert.Equal(1, NumberOfIslands.RunNumberOfIslandsRecursive(grid));
    }

    private static char[][] GetGrid1() {
        return new char[][] {
            ['1', '1', '1', '1', '0'],
            ['1', '1', '0', '1', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '0', '0', '0']
        };
    }

    private static char[][] GetGrid2() {
        return new char[][] {
            ['1', '1', '0', '0', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '1', '0', '0'],
            ['0', '0', '0', '1', '1']
        };
    }
}