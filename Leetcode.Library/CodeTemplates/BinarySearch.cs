namespace Leetcode.CodeTemplates;

public abstract class BinarySearch {
    public static int RunBinarySearch(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;

        while (l <= r) {
            // Avoids overflow, slightly faster than division
            var mid = (int)((uint)(l + r) >> 1);
            var midVal = nums[mid];

            if (target == midVal)
                return mid;

            if (target < midVal)
                r = mid - 1;
            else
                l = mid + 1;
        }

        return -1;
    }
}