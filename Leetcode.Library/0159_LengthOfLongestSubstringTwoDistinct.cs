namespace Leetcode;

/// <summary>
///     Provides a method to find the length of the longest substring with at most two distinct characters.
/// </summary>
public class LengthOfLongestSubstringTwoDistinct {
    /// <summary>
    ///     Returns the length of the longest substring containing at most two distinct characters.
    /// </summary>
    /// <param name="s">The input string to be evaluated.</param>
    /// <returns>The length of the longest valid substring.</returns>
    public int RunLengthOfLongestSubstringTwoDistinct(string s) {
        // Get the length of the input string.
        var len = s.Length;

        // If the string has 2 or fewer characters, return its length.
        if (len <= 2) return len;

        // Initialize the maximum length found to 2 (minimum valid substring).
        var max = 2;

        // Initialize the left and right pointers for the sliding window.
        int l = 0, r = 0;

        // Dictionary to store the count of each character in the current window.
        var dc = new Dictionary<char, int>();

        // Iterate through the string using the right pointer.
        while (r < len) {
            // If the character at r is not in the dictionary, add it with count 0.
            if (!dc.ContainsKey(s[r]))
                dc[s[r]] = 0;

            // Increment the count for the character at r.
            dc[s[r]]++;

            // If there are more than two distinct characters in the window, shrink the window from the left.
            while (dc.Count > 2) {
                // Decrement the count for the character at l.
                dc[s[l]]--;

                // If the count becomes zero, remove the character from the dictionary.
                if (dc[s[l]] == 0)
                    dc.Remove(s[l]);

                // Move the left pointer to the right.
                l++;
            }

            // Update the maximum length if the current window is larger.
            max = Math.Max(max, r - l + 1);

            // Move the right pointer to the right.
            r++;
        }

        // Return the maximum length found.
        return max;
    }
}