using System.Text;

namespace Leetcode;

public class CountDistinct {
    public int RunCountDistinct(int[] nums, int k, int p) {
        var n = nums.Length;
        var seen = new HashSet<string>();

        for (var start = 0; start < n; start++) {
            var divCount = 0;
            var sb = new StringBuilder();

            for (var end = start; end < n; end++) {
                if (nums[end] % p == 0) divCount++;
                if (divCount > k) break;

                if (end > start) sb.Append(',');
                sb.Append(nums[end]);
                seen.Add(sb.ToString());
            }
        }

        return seen.Count;
    }
}