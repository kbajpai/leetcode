using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class MinDifferenceTests {
    [Fact]
    public void RunMinDifference_AllElementsEqual_ReturnsZero() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([7, 7, 7, 7, 7, 7]);
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinDifference_ArrayWithFourOrFewerElements_ReturnsZero() {
        var minDiff = new MinDifference();
        Assert.Equal(0, minDiff.RunMinDifference([1]));
        Assert.Equal(0, minDiff.RunMinDifference([1, 2]));
        Assert.Equal(0, minDiff.RunMinDifference([1, 2, 3]));
        Assert.Equal(0, minDiff.RunMinDifference([1, 2, 3, 4]));
    }

    [Fact]
    public void RunMinDifference_DescendingOrderInput_ReturnsCorrectMinDifference() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([100, 90, 80, 70, 60, 50, 40]);
        Assert.Equal(30, result);
    }

    [Fact]
    public void RunMinDifference_GeneralCase_ReturnsCorrectMinDifference() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([1, 5, 6, 14, 15]);
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunMinDifference_LargerArray_ReturnsCorrectMinDifference() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([20, 10, 30, 40, 100, 50]);
        Assert.Equal(20, result);
    }

    [Fact]
    public void RunMinDifference_PublicDomainCase1() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([6, 6, 0, 1, 1, 4, 6]);
        Assert.Equal(2, result);
    }

    [Fact]
    public void RunMinDifference_PublicDomainCase2() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([1, 5, 0, 10, 14]);
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunMinDifference_PublicDomainCase3() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([1, 5, 6, 14, 15]);
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunMinDifference_PublicDomainCase4() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([1, 3, 3, 5, 7, 8, 9, 10]);
        Assert.Equal(5, result);
    }

    [Fact]
    public void RunMinDifference_PublicDomainCase5() {
        var minDiff = new MinDifference();
        var result = minDiff.RunMinDifference([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        Assert.Equal(6, result);
    }
}