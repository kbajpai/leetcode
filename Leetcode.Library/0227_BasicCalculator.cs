namespace Leetcode {
    public abstract class BasicCalculator {
        public static int Calculate(string s) {
            if (string.IsNullOrEmpty(s)) {
                return 0;
            }

            var stack = new Stack<int>();
            var currentNumber = 0;
            var operation = '+';

            for (var i = 0; i < s.Length; i++) {
                var c = s[i];

                // Build the current number
                if (char.IsDigit(c)) {
                    currentNumber = currentNumber * 10 + (c - '0');
                }

                // Process operation when we hit an operator or reach the end
                if (c == '+' || c == '-' || c == '*' || c == '/' || i == s.Length - 1) {
                    switch (operation) {
                        case '+':
                            stack.Push(currentNumber);
                            break;
                        case '-':
                            stack.Push(-currentNumber);
                            break;
                        case '*':
                            stack.Push(stack.Pop() * currentNumber);
                            break;
                        case '/':
                            stack.Push(stack.Pop() / currentNumber);
                            break;
                    }

                    // Reset for next number and operation
                    currentNumber = 0;
                    operation = c;
                }
            }

            // Sum all values in the stack
            var result = 0;
            while (stack.Count > 0) {
                result += stack.Pop();
            }

            return result;
        }
    }
}