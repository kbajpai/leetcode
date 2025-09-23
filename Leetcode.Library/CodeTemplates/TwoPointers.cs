namespace Leetcode.CodeTemplates;

public abstract class TwoPointers {
    public static bool IsPalindrome(string s) {
        var n = s.Length;

        if (n <= 1) {
            return true;
        }

        int l = 0, r = n - 1;
        while (l < r) {
            if (s[l++] != s[r--]) {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Finds the indices of the two numbers in the array that add up to the specified target.
    ///     Assumes exactly one solution exists and the same element cannot be used twice.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>
    ///     An array containing the indices of the two numbers that add up to the target.
    /// </returns>
    public static int[] TwoSum(int[] nums, int target) {
        var n = nums.Length;

        if (n <= 1) {
            return [-1, -1];
        }

        var dc = new Dictionary<int, int>(n);
        for (var i = 0; i < n; i++) {
            var complement = target - nums[i];
            if (dc.TryGetValue(complement, out var v) && v != i) {
                return [v, i];
            }

            dc[nums[i]] = i;
        }

        return [-1, -1];
    }
}