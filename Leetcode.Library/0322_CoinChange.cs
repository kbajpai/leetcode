namespace Leetcode {
    public abstract class CoinChange {
        public static int RunCoinChange(int[] coins, int amount) {
            if (amount == 0) return 0;
            if (coins.Length == 0) return -1;

            // Dynamic programming approach: dp[a] = fewest coins needed to make amount a
            // Initialize dp with a sentinel value greater than any possible coin count (amount + 1)
            var dp = new int[amount + 1];
            for (var i = 1; i <= amount; i++) 
                dp[i] = amount + 1;
            
            dp[0] = 0;

            for (var a = 1; a <= amount; a++) {
                foreach (var c in coins) {
                    if (c <= 0) continue;
                    if (c <= a) {
                        dp[a] = Math.Min(dp[a], dp[a - c] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}