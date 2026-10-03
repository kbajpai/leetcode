using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class IsMatchTests {
    [Theory]
    [InlineData("aa", "a", false)]
    [InlineData("aa", "a*", true)]
    [InlineData("ab", ".*", true)]
    [InlineData("aab", "c*a*b", true)]
    [InlineData("mississippi", "mis*is*p*.", false)]
    [InlineData("", ".*", true)]
    [InlineData("", "", true)]
    [InlineData("abc", "abc", true)]
    [InlineData("aaa", "a*a", true)]
    [InlineData("aaa", "ab*a*c*a", true)]
    [InlineData("a", "ab*", true)]
    [InlineData("bbbba", ".*a*a", true)]
    [InlineData("abcd", "d*", false)]
    [InlineData("c*a*b", "c*a*b", false)]
    public void RunIsMatch_ExamplesAndEdgeCases(string s, string p, bool expected) {
        var matcher = new IsMatch();
        Assert.Equal(expected, IsMatch.RunIsMatch(s, p));
    }
}