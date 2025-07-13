namespace Leetcode.CodeTemplates;

public class PrefixSum {
    //Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.
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
}