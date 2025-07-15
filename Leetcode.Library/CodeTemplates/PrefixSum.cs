namespace Leetcode.CodeTemplates;

/// <summary>
///     Contains algorithms that use prefix sum techniques to solve array problems efficiently.
/// </summary>
public class PrefixSum {
    /// <summary>
    ///     Finds the maximum length of a contiguous subarray with an equal number of 0s and 1s.
    ///     Uses a prefix sum approach by treating 0s as -1 and 1s as +1, then tracking balance occurrences.
    /// </summary>
    /// <param name="nums">A binary array containing only 0s and 1s.</param>
    /// <returns>
    ///     The maximum length of a contiguous subarray with equal numbers of 0s and 1s. Returns 0 if no such subarray
    ///     exists.
    /// </returns>
    /// <remarks>
    ///     Time Complexity: O(n) - single pass through the array
    ///     Space Complexity: O(n) - for storing first occurrence of each balance value
    ///     Algorithm:
    ///     1. Maintain a running balance: +1 for each '1', -1 for each '0'
    ///     2. Store the first occurrence index of each balance value
    ///     3. When the same balance appears again, the subarray between occurrences has equal 0s and 1s
    ///     4. Track the maximum length found
    /// </remarks>
    /// <example>
    ///     Input: [0,1,0,0,1,1,0]
    ///     Output: 6 (subarray [0,1,0,0,1,1] from index 0 to 5)
    /// </example>
    public int FindMaxLength(int[] nums) {
        var arrayLength = nums.Length;

        // Array to store first occurrence of each balance value
        // Size: 2*n+1 to handle balance range from -n to +n
        var firstOccurrence = new int[2 * arrayLength + 1];
        Array.Fill(firstOccurrence, -2); // -2 indicates "not seen yet"

        // Initialize: balance of 0 occurs at imaginary index -1 (before array starts)
        firstOccurrence[arrayLength] = -1;

        var maxSubarrayLength = 0;
        var balance = 0; // running balance: +1 for each '1', -1 for each '0'

        for (var currentIndex = 0; currentIndex < arrayLength; currentIndex++) {
            // Update balance: treat 0 as -1, keep 1 as +1
            balance += nums[currentIndex] == 1 ? 1 : -1;

            // Convert balance to array index (add offset to handle negative values)
            var balanceArrayIndex = balance + arrayLength;

            if (firstOccurrence[balanceArrayIndex] != -2) {
                // We've seen this balance before - subarray between indices has equal 0s and 1s
                var subarrayLength = currentIndex - firstOccurrence[balanceArrayIndex];
                maxSubarrayLength = Math.Max(maxSubarrayLength, subarrayLength);
            }
            else {
                // First time seeing this balance - record the index
                firstOccurrence[balanceArrayIndex] = currentIndex;
            }
        }

        return maxSubarrayLength;
    }

    /// <summary>
    ///     Returns the total number of continuous subarrays whose sum equals to k.
    ///     Uses a prefix sum and hash map to achieve O(n) time complexity.
    /// </summary>
    /// <param name="nums">The input integer array.</param>
    /// <param name="k">The target sum.</param>
    /// <returns>The count of subarrays whose sum is k.</returns>
    public int SubarraySum(int[] nums, int k) {
        var count = 0;
        var prefixSum = 0;
        var sumOccurrences = new Dictionary<int, int> { [0] = 1 };

        foreach (var n in nums) {
            prefixSum += n;
            if (sumOccurrences.TryGetValue(prefixSum - k, out var freq)) {
                count += freq;
            }

            if (!sumOccurrences.TryAdd(prefixSum, 1)) {
                sumOccurrences[prefixSum]++;
            }
        }

        return count;
    }
}