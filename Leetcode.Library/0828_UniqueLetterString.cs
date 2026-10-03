namespace Leetcode;

public class UniqueLetterString {
    /// <summary>
    ///     Returns the sum of unique characters in all substrings of s.
    ///     Time Complexity: O(n), Space Complexity: O(1) - constant alphabet size
    /// </summary>
    public int RunUniqueLetterString(string s) {
        var n = s.Length;
        var result = 0;

        // For each character, calculate its contribution across all substrings
        for (var i = 0; i < n; i++) {
            // Find previous occurrence of current character
            var prevIndex = -1;
            for (var j = i - 1; j >= 0; j--) {
                if (s[j] == s[i]) {
                    prevIndex = j;
                    break;
                }
            }

            // Find next occurrence of current character
            var nextIndex = n;
            for (var j = i + 1; j < n; j++) {
                if (s[j] == s[i]) {
                    nextIndex = j;
                    break;
                }
            }

            // Calculate contribution: number of substrings where s[i] is unique
            // Left choices: i - prevIndex, Right choices: nextIndex - i
            result += (i - prevIndex) * (nextIndex - i);
        }

        return result;
    }
}