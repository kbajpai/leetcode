namespace Leetcode.CodeTemplates;

/// <summary>
///     Provides utility methods for working with two-dimensional integer arrays.
/// </summary>
public abstract class TwoDimensionalArray {
    /// <summary>
    ///     Declares and initializes a two-dimensional integer array with the specified number of rows and columns.
    ///     Each element is set to <c>i * cols + j</c>, where <c>i</c> is the row index and <c>j</c> is the column index.
    /// </summary>
    /// <param name="rows">The number of rows in the array.</param>
    /// <param name="cols">The number of columns in the array.</param>
    /// <returns>
    ///     A two-dimensional integer array of size <c>rows</c> by <c>cols</c> with initialized values.
    /// </returns>
    public static int[,] DeclareAndInitialize(int rows, int cols) {
        var array = new int[rows, cols];
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                array[i, j] = i * cols + j;
            }
        }

        return array;
    }

    /// <summary>
    ///     Declares and initializes a jagged integer array with the specified number of rows and columns.
    ///     Each element is set to <c>i * cols + j</c>, where <c>i</c> is the row index and <c>j</c> is the column index.
    /// </summary>
    /// <param name="rows">The number of rows in the jagged array.</param>
    /// <param name="cols">The number of columns in each row.</param>
    /// <returns>
    ///     A jagged integer array of size <c>rows</c> by <c>cols</c> with initialized values.
    /// </returns>
    public static int[][] DeclareAndInitializeJagged(int rows, int cols) {
        var array = new int[rows][];
        for (var i = 0; i < rows; i++) {
            array[i] = new int[cols];
            for (var j = 0; j < cols; j++) {
                array[i][j] = i * cols + j;
            }
        }

        return array;
    }

    /// <summary>
    ///     Traverses a two-dimensional integer array in row-major order and yields each element.
    /// </summary>
    /// <param name="array">
    ///     The two-dimensional integer array to traverse.
    /// </param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of integers representing the elements of the array in row-major order.
    /// </returns>
    public static IEnumerable<int> Traverse(int[,] array) {
        // Get the number of rows in the array
        var rows = array.GetLength(0);

        // Get the number of columns in the array
        var cols = array.GetLength(1);

        // Iterate over each row
        for (var i = 0; i < rows; i++) {
            // Iterate over each column in the current row
            for (var j = 0; j < cols; j++) {
                // Yield the current element in row-major order
                yield return array[i, j];
            }
        }
    }
}