namespace Leetcode {
    public abstract class RemoveBoxes {
        public static int RunRemoveBoxes(int[] boxes) {
            if (boxes.Length == 0) {
                return 0;
            }

            var memo = new Dictionary<(int Left, int Right, int Carry), int>();
            return Dp(0, boxes.Length - 1, 0);

            int Dp(int left, int right, int carry) {
                if (left > right) {
                    return 0;
                }

                var key = (left, right, carry);
                if (memo.TryGetValue(key, out var cached)) {
                    return cached;
                }

                var currentLeft = left;
                var currentCarry = carry;

                while (currentLeft < right && boxes[currentLeft] == boxes[currentLeft + 1]) {
                    currentLeft++;
                    currentCarry++;
                }

                var best = (currentCarry + 1) * (currentCarry + 1) + Dp(currentLeft + 1, right, 0);

                for (var i = currentLeft + 1; i <= right; i++) {
                    if (boxes[i] == boxes[currentLeft]) {
                        var candidate = Dp(currentLeft + 1, i - 1, 0) + Dp(i, right, currentCarry + 1);
                        if (candidate > best) {
                            best = candidate;
                        }
                    }
                }

                memo[key] = best;
                return best;
            }
        }
    }
}