namespace Leetcode;

public class ThreeSum {
    public static IList<IList<int>> FindThreeSum(int[] nums) {
        // Step 1: Sort the array
        Array.Sort(nums);

        // Use concrete type for better performance
        var result = new List<IList<int>>();

        for (int i = 0, n = nums.Length; i < n - 2; i++) {
            // Skip duplicates for nums[i]
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1, right = n - 1;
            while (left < right) {
                var sum = nums[i] + nums[left] + nums[right];
                switch (sum) {
                    case 0: {
                        // Use array instead of List<int> for efficiency
                        result.Add([nums[i], nums[left], nums[right]]);

                        // Skip duplicates for left and right
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                        break;
                    }
                    case < 0:
                        // Increase sum
                        left++;
                        break;
                    default:
                        // Decrease sum
                        right--;
                        break;
                }
            }
        }

        return result;
    }
}