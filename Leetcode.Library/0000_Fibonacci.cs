namespace Leetcode;

/// <summary>
///     Provides methods to calculate Fibonacci numbers using memoization.
/// </summary>
public static class Fibonacci {
    // Dictionary to store previously computed Fibonacci numbers for memoization.
    private static readonly Dictionary<int, int> memoize = new();

    /// <summary>
    ///     Calculates the nth Fibonacci number using a recursive approach with memoization.
    /// </summary>
    /// <param name="n">The position of the Fibonacci sequence to calculate (0-based index).</param>
    /// <returns>The nth Fibonacci number.</returns>
    /// <remarks>
    ///     Time Complexity: O(n) - Each Fibonacci number is computed once and stored in the dictionary.
    ///     Space Complexity: O(n) - Space is used to store the memoized results in the dictionary.
    /// </remarks>
    public static int RunFibonacci(int n) {
        if (n <= 1) {
            return 1;
        }

        if (memoize.TryGetValue(n, out var v)) {
            return v;
        }

        memoize[n] = RunFibonacci(n - 1) + RunFibonacci(n - 2);

        return memoize[n];
    }
}