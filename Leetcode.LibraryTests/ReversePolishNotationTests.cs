using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class ReversePolishNotationTests {
    [Fact]
    public void RunReversePolishNotation_BasicOperations_ReturnsCorrectResult() {
        var tokens = new[] { "2", "1", "+", "3", "*" };
        var result = ReversePolishNotation.RunReversePolishNotation(tokens);
        Assert.Equal(9, result);
    }

    [Fact]
    public void RunReversePolishNotation_ComplexExpression_ReturnsExpected() {
        var tokens = new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
        var result = ReversePolishNotation.RunReversePolishNotation(tokens);
        Assert.Equal(22, result);
    }

    [Fact]
    public void RunReversePolishNotation_DivisionAndAddition_ReturnsCorrectResult() {
        var tokens = new[] { "4", "13", "5", "/", "+" };
        var result = ReversePolishNotation.RunReversePolishNotation(tokens);
        Assert.Equal(6, result); // 13/5 == 2 -> 4 + 2 == 6
    }

    [Fact]
    public void RunReversePolishNotation_NegativeDivision_TruncatesTowardZero() {
        var tokens = new[] { "-7", "3", "/" };
        var result = ReversePolishNotation.RunReversePolishNotation(tokens);
        Assert.Equal(-2, result); // -7/3 == -2 in C#
    }

    [Fact]
    public void RunReversePolishNotation_SingleNumber_ReturnsNumber() {
        var tokens = new[] { "42" };
        var result = ReversePolishNotation.RunReversePolishNotation(tokens);
        Assert.Equal(42, result);
    }
}