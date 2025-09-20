using Xunit;
using Leetcode;

namespace LeetcodeTests;

public class NumberOfIslandsTests
{
    [Fact]
    public void Test_EmptyGrid_ReturnsZero()
    {
        char[][] grid = new char[0][];
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslands(grid));
    }

    [Fact]
    public void Test_AllWater_ReturnsZero()
    {
        char[][] grid = new[]
        {
            new[] {'0', '0'},
            new[] {'0', '0'}
        };
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslands(grid));
    }

    [Fact]
    public void Test_AllLand_ReturnsOne()
    {
        char[][] grid = new[]
        {
            new[] {'1', '1'},
            new[] {'1', '1'}
        };
        Assert.Equal(1, NumberOfIslands.RunNumberOfIslands(grid));
    }

    [Fact]
    public void Test_MultipleIslands()
    {
        char[][] grid = new[]
        {
            new[] {'1', '1', '0', '0', '0'},
            new[] {'1', '1', '0', '0', '0'},
            new[] {'0', '0', '1', '0', '0'},
            new[] {'0', '0', '0', '1', '1'}
        };
        Assert.Equal(3, NumberOfIslands.RunNumberOfIslands(grid));
    }

    [Fact]
    public void Test_SingleCellIsland()
    {
        char[][] grid = new[]
        {
            new[] {'1'}
        };
        Assert.Equal(1, NumberOfIslands.RunNumberOfIslands(grid));
    }

    [Fact]
    public void Test_SingleCellWater()
    {
        char[][] grid = new[]
        {
            new[] {'0'}
        };
        Assert.Equal(0, NumberOfIslands.RunNumberOfIslands(grid));
    }
}
