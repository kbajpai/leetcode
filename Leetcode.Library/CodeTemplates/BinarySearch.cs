namespace Leetcode.CodeTemplates;

public abstract class BinarySearch {
    public static int RunBinarySearch(int[] nums, int target) {
        var n = nums.Length;
        int l = 0, r = n - 1;

        while (l <= r) {
            var mid = l + (r - l) / 2;
            var midVal = nums[mid];

            if (target == midVal)
                return mid;

            if (target < midVal) {
                r = mid - 1;
            }
            else {
                l = mid + 1;
            }
        }

        return -1;
    }
}