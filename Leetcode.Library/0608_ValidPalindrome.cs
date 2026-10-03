namespace Leetcode {
    public abstract class ValidPalindrome {
        public static bool RunValidPalindrome(string s) {
            var left = 0;
            var right = s.Length - 1;

            while (left < right) {
                if (s[left] != s[right]) {
                    // Try skipping left character or right character
                    return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
                }

                left++;
                right--;
            }

            return true;
        }

        private static bool IsPalindrome(string s, int left, int right) {
            while (left < right) {
                if (s[left] != s[right]) {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
    }
}