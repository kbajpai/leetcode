using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class FibonacciTests {
    [Fact]
    public void RunFibonacci_LargeN_ReturnsCorrectValue() {
        // Act
        var result = Fibonacci.RunFibonacci(20);

        // Assert
        Assert.Equal(10946, result);
    }

    [Fact]
    public void RunFibonacci_NIsFive_ReturnsEight() {
        // Act
        var result = Fibonacci.RunFibonacci(5);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void RunFibonacci_NIsOne_ReturnsOne() {
        // Act
        var result = Fibonacci.RunFibonacci(1);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunFibonacci_NIsTen_ReturnsEightyNine() {
        // Act
        var result = Fibonacci.RunFibonacci(10);

        // Assert
        Assert.Equal(89, result);
    }

    [Fact]
    public void RunFibonacci_NIsTwo_ReturnsTwo() {
        // Act
        var result = Fibonacci.RunFibonacci(2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void RunFibonacci_NIsZero_ReturnsOne() {
        // Act
        var result = Fibonacci.RunFibonacci(0);

        // Assert
        Assert.Equal(1, result);
    }
}