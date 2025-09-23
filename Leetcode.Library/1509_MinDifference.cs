namespace Leetcode;

public class MinDifference {
    public int RunMinDifference(int[] nums) {
        var n = nums.Length;
        if (n <= 4) {
            return 0;
        }

        // Use Array.Sort for in-place sorting (already optimal for performance)
        Array.Sort(nums);

        // Unroll the loop for better performance and clarity
        var diff1 = nums[^1] - nums[3];
        var diff2 = nums[^2] - nums[2];
        var diff3 = nums[^3] - nums[1];
        var diff4 = nums[^4] - nums[0];

        // Return the minimum of the four differences
        var minDiff = diff1;
        if (diff2 < minDiff) {
            minDiff = diff2;
        }

        if (diff3 < minDiff) {
            minDiff = diff3;
        }

        if (diff4 < minDiff) {
            minDiff = diff4;
        }

        return minDiff;
    }
}