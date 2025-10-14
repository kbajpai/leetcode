using System.Text;

namespace Leetcode {
    public abstract class MinRemoveToMakeValid {
        public static string RunMinRemoveToMakeValid(string s) {
            if (string.IsNullOrEmpty(s)) {
                return s;
            }

            var n = s.Length;
            var openStack = new Stack<int>();
            var toRemove = new HashSet<int>();

            // First pass: identify invalid parentheses
            for (var i = 0; i < n; i++) {
                switch (s[i]) {
                    case '(':
                        openStack.Push(i);
                        break;
                    case ')':
                        if (openStack.Count > 0) {
                            openStack.Pop(); // Valid pair found
                        }
                        else {
                            toRemove.Add(i); // Invalid closing parenthesis
                        }

                        break;
                }
            }

            // Add remaining unmatched opening parentheses to removal set
            while (openStack.Count > 0) {
                toRemove.Add(openStack.Pop());
            }

            // Build result string efficiently
            var sb = new StringBuilder(n - toRemove.Count);
            for (var i = 0; i < n; i++) {
                if (!toRemove.Contains(i)) {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
    }
}