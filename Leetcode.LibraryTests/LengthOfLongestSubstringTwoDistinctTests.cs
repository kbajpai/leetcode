using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class LengthOfLongestSubstringTwoDistinctTests {
    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_AllDistinct() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(2, solver.RunLengthOfLongestSubstringTwoDistinct("abcdef"));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_AllSameChar_ReturnsLength() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(5, solver.RunLengthOfLongestSubstringTwoDistinct("aaaaa"));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_EmptyString_ReturnsZero() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(0, solver.RunLengthOfLongestSubstringTwoDistinct(""));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_Example1() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(3, solver.RunLengthOfLongestSubstringTwoDistinct("eceba"));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_Example2() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(5, solver.RunLengthOfLongestSubstringTwoDistinct("ccaabbb"));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_MultipleSwitches() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(4, solver.RunLengthOfLongestSubstringTwoDistinct("abaccc"));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_OneChar_ReturnsOne() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(1, solver.RunLengthOfLongestSubstringTwoDistinct("a"));
    }

    [Fact]
    public void RunLengthOfLongestSubstringTwoDistinct_TwoChars_ReturnsTwo() {
        var solver = new LengthOfLongestSubstringTwoDistinct();
        Assert.Equal(2, solver.RunLengthOfLongestSubstringTwoDistinct("ab"));
    }
}