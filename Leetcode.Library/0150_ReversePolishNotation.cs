namespace Leetcode;

public abstract class ReversePolishNotation {
    public static int RunReversePolishNotation(string[] tokens) {
        // Use a Stack<int> to avoid repeated string allocations and parsing on operators.
        var st = new Stack<int>(tokens.Length);
        foreach (var token in tokens) {
            // Operators are single-character tokens in valid RPN inputs.
            if (token.Length == 1) {
                var op = token[0];
                if (op is '+' or '-' or '*' or '/') {
                    var rhs = st.Pop();
                    var lhs = st.Pop();
                    var res = op switch {
                        '+' => lhs + rhs,
                        '-' => lhs - rhs,
                        '*' => lhs * rhs,
                        _ => lhs / rhs
                    };

                    st.Push(res);
                    continue;
                }
            }

            // Parse and push numbers (maybe multi-character, e.g. "-11" or "123")
            st.Push(int.Parse(token));
        }

        return st.Pop();
    }
}