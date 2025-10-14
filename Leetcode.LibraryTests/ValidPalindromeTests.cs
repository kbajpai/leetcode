using Leetcode;
using Xunit;

namespace LeetcodeTests {
    public class ValidPalindromeTests {
        [Fact]
        public void ValidPalindrome_ComplexLongCase_ReturnsTrue() {
            // Arrange - complex test case from original
            const string S_COMPLEX_CASE =
                "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga";

            // Act & Assert
            Assert.True(ValidPalindrome.RunValidPalindrome(S_COMPLEX_CASE));
        }

        [Theory]
        [InlineData("abc", false)] // Cannot make palindrome by skipping one character
        [InlineData("abcdefg", false)] // No way to make palindrome
        [InlineData("abcdefba", false)] // Cannot make palindrome
        [InlineData("abcdefcba", false)] // Too many differences
        [InlineData("abcdefghijklmnopqrstuvwxyz", false)] // Alphabet - definitely not palindrome
        public void ValidPalindrome_InvalidCases_ReturnsFalse(string input, bool expected) {
            // Act & Assert
            Assert.Equal(expected, ValidPalindrome.RunValidPalindrome(input));
        }

        [Fact]
        public void ValidPalindrome_LongAlmostPalindrome_ReturnsTrue() {
            // Arrange - palindrome with one extra character in the middle
            const string S_ALMOST_PALINDROME = "abcdefghijklmnopqrstuvwxyzzxyxwvutsrqponmlkjihgfedcba";

            // Act & Assert
            Assert.True(ValidPalindrome.RunValidPalindrome(S_ALMOST_PALINDROME));
        }

        [Fact]
        public void ValidPalindrome_LongValidPalindrome_ReturnsTrue() {
            // Arrange
            const string S_LONG_PALINDROME = "abcdefghijklmnopqrstuvwxyzzyxwvutsrqponmlkjihgfedcba";

            // Act & Assert
            Assert.True(ValidPalindrome.RunValidPalindrome(S_LONG_PALINDROME));
        }

        [Theory]
        [InlineData("", true)] // Empty string
        [InlineData("a", true)] // Single character
        [InlineData("aa", true)] // Two same characters
        [InlineData("ab", true)] // Two different characters (can skip one)
        [InlineData("aba", true)] // Already a palindrome
        [InlineData("abca", true)] // Can skip 'c' to make "aba"
        [InlineData("racecar", true)] // Already a palindrome
        [InlineData("raceacar", true)] // Can skip one 'a' to make "racecar"
        [InlineData("race a car", true)] // Can skip space to make "racecar"
        [InlineData("abcddcba", true)] // Already a palindrome
        [InlineData("abcdedcba", true)] // Already a palindrome
        [InlineData("deeee", true)] // Can skip first 'd' to make "eeee"
        [InlineData("eeeed", true)] // Can skip last 'd' to make "eeee"
        [InlineData("eeeee", true)] // Already a palindrome
        [InlineData("abcdecba", true)] // Can skip 'd' to make "abcecba"
        [InlineData("madam", true)] // Classic palindrome
        [InlineData("madame", true)] // Can skip 'e' to make "madam"
        [InlineData("madxam", true)] // Can skip 'x' to make "madam"
        [InlineData("mxadam", true)] // Can skip 'x' to make "madam"
        [InlineData("abcdcba", true)] // Already palindrome
        [InlineData("abcxdcba", true)] // Can skip 'x' to make palindrome
        [InlineData("aaaaaaaaaa", true)] // Repeating characters
        [InlineData("aaaaabaaaa", true)] // Almost repeating characters
        public void ValidPalindrome_ValidCases_ReturnsTrue(string input, bool expected) {
            // Act & Assert
            Assert.Equal(expected, ValidPalindrome.RunValidPalindrome(input));
        }
    }
}