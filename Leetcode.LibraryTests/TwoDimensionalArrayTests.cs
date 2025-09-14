using Leetcode.CodeTemplates;
using Xunit;

namespace LeetcodeTests;

public class TwoDimensionalArrayTests {
    [Theory]
    [InlineData(1, 1, new[] { 0 })]
    [InlineData(2, 3, new[] { 0, 1, 2, 3, 4, 5 })]
    [InlineData(3, 2, new[] { 0, 1, 2, 3, 4, 5 })]
    public void DeclareAndInitialize_ReturnsCorrectValues(int rows, int cols, int[] expected) {
        var result = TwoDimensionalArray.DeclareAndInitialize(rows, cols);
        Assert.Equal(rows, result.GetLength(0));
        Assert.Equal(cols, result.GetLength(1));
        Assert.Equal(expected, TwoDimensionalArray.Traverse(result).ToArray());
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    public void DeclareAndInitialize_ZeroDimensions_ReturnsEmptyArray(int rows, int cols) {
        var result = TwoDimensionalArray.DeclareAndInitialize(rows, cols);
        Assert.Equal(rows, result.GetLength(0));
        Assert.Equal(cols, result.GetLength(1));
        Assert.Empty(TwoDimensionalArray.Traverse(result));
    }

    [Theory]
    [InlineData(1, 1, new[] { 0 })]
    [InlineData(2, 3, new[] { 0, 1, 2, 3, 4, 5 })]
    [InlineData(3, 2, new[] { 0, 1, 2, 3, 4, 5 })]
    public void DeclareAndInitializeJagged_ReturnsCorrectValues(int rows, int cols, int[] expected) {
        var result = TwoDimensionalArray.DeclareAndInitializeJagged(rows, cols);
        Assert.Equal(rows, result.Length);
        Assert.Equal(expected, result.SelectMany(r => r).ToArray());
    }

    [Fact]
    public void DeclareAndInitializeJagged_ZeroCols_ReturnsArrayWithEmptyRows() {
        var result = TwoDimensionalArray.DeclareAndInitializeJagged(2, 0);
        Assert.Equal(2, result.Length);
        Assert.All(result, r => Assert.Empty(r));
    }

    [Fact]
    public void DeclareAndInitializeJagged_ZeroRows_ReturnsEmptyArray() {
        var result = TwoDimensionalArray.DeclareAndInitializeJagged(0, 3);
        Assert.Empty(result);
    }

    [Fact]
    public void IntegrationTest_CompareRegularAndJaggedArrays_SameInitialization() {
        const int rows = 3;
        const int cols = 2;
        var regularArray = TwoDimensionalArray.DeclareAndInitialize(rows, cols);
        var jaggedArray = TwoDimensionalArray.DeclareAndInitializeJagged(rows, cols);
        var regularTraversed = TwoDimensionalArray.Traverse(regularArray).ToArray();
        var jaggedTraversed = jaggedArray.SelectMany(row => row).ToArray();
        Assert.Equal(regularTraversed, jaggedTraversed);
    }

    [Fact]
    public void IntegrationTest_DeclareInitializeAndTraverse_RegularArray() {
        var array = TwoDimensionalArray.DeclareAndInitialize(2, 3);
        Assert.Equal(new[] { 0, 1, 2, 3, 4, 5 }, TwoDimensionalArray.Traverse(array).ToArray());
    }

    [Fact]
    public void Traverse_1x1Array_ReturnsCorrectSequence() {
        var array = new[,] { { 42 } };
        Assert.Equal(new[] { 42 }, TwoDimensionalArray.Traverse(array).ToArray());
    }

    [Fact]
    public void Traverse_2x3Array_ReturnsRowMajorOrder() {
        var array = new[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, TwoDimensionalArray.Traverse(array).ToArray());
    }

    [Fact]
    public void Traverse_3x2Array_ReturnsRowMajorOrder() {
        var array = new[,] { { 10, 20 }, { 30, 40 }, { 50, 60 } };
        Assert.Equal(new[] { 10, 20, 30, 40, 50, 60 }, TwoDimensionalArray.Traverse(array).ToArray());
    }

    [Fact]
    public void Traverse_CanBeEnumeratedMultipleTimes() {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var enumerable = TwoDimensionalArray.Traverse(array);
        Assert.Equal(new[] { 1, 2, 3, 4 }, enumerable.ToArray());
        Assert.Equal(new[] { 1, 2, 3, 4 }, enumerable.ToList());
    }

    [Fact]
    public void Traverse_EmptyArray_ReturnsEmptySequence() {
        var array = new int[0, 0];
        Assert.Empty(TwoDimensionalArray.Traverse(array).ToArray());
    }

    [Fact]
    public void Traverse_IsLazyEvaluated_DoesNotEnumerateUntilRequested() {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var enumerable = TwoDimensionalArray.Traverse(array);
        Assert.NotNull(enumerable);
        Assert.Equal(new[] { 1, 2, 3, 4 }, enumerable.ToArray());
    }

    [Fact]
    public void Traverse_SingleColumnArray_ReturnsCorrectSequence() {
        var array = new[,] { { 1 }, { 2 }, { 3 }, { 4 } };
        Assert.Equal(new[] { 1, 2, 3, 4 }, TwoDimensionalArray.Traverse(array).ToArray());
    }

    [Fact]
    public void Traverse_SingleRowArray_ReturnsCorrectSequence() {
        var array = new[,] { { 1, 2, 3, 4, 5 } };
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, TwoDimensionalArray.Traverse(array).ToArray());
    }
}