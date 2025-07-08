namespace Leetcode;

/// <summary>
///     Provides a method to perform regular expression matching with support for '.' and '*'.
/// </summary>
public class IsMatch {
    /// <summary>
    ///     Determines if the input string matches the given pattern.
    ///     The pattern may contain '.' which matches any single character and '*' which matches zero or more of the preceding
    ///     element.
    /// </summary>
    /// <param name="s">The input string to match.</param>
    /// <param name="p">The pattern string, which may contain '.' and '*'.</param>
    /// <returns>True if the string matches the pattern; otherwise, false.</returns>
    public static bool RunIsMatch(string s, string p) {
        int m = s.Length, n = p.Length;

        // dp[i][j] represents whether s[0...i-1] matches p[0...j-1]
        var dp = new bool[m + 1, n + 1];

        // Empty string matches empty pattern
        dp[0, 0] = true;

        // Handle patterns like a*, a*b*, a*b*c* that can match empty string
        for (var j = 2; j <= n; j += 2) {
            if (p[j - 1] == '*') {
                dp[0, j] = dp[0, j - 2];
            }
        }

        for (var i = 1; i <= m; i++) {
            for (var j = 1; j <= n; j++) {
                if (p[j - 1] == '*') {
                    // '*' can match zero or more of the preceding character
                    dp[i, j] = dp[i, j - 2]; // Zero occurrences

                    // One or more occurrences if current char matches preceding char
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1]) {
                        dp[i, j] = dp[i, j] || dp[i - 1, j];
                    }
                }
                else if (p[j - 1] == '.' || p[j - 1] == s[i - 1]) {
                    // Current characters match
                    dp[i, j] = dp[i - 1, j - 1];
                }
            }
        }

        return dp[m, n];
    }
}