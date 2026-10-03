namespace Leetcode;

public class SmallestDivisor {
    public int FindSmallestDivisor(int[] nums, int threshold) {
        int left = 1, right = nums.Max();
        var result = right;

        while (left <= right) {
            var mid = left + (right - left) / 2;
            var sum = 0;

            foreach (var num in nums) {
                sum += (num + mid - 1) / mid; // Equivalent to Math.Ceiling((double)num / mid)
            }

            if (sum <= threshold) {
                result = mid;
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }

        return result;
    }
}