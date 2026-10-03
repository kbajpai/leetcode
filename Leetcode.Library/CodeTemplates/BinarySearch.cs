namespace Leetcode.CodeTemplates;

/// <summary>
///     Provides a template for performing binary search operations on sorted arrays.
/// </summary>
public abstract class BinarySearch {
    /// <summary>
    ///     Searches for a target value within a sorted integer array using binary search.
    /// </summary>
    /// <param name="nums">A sorted array of integers to search.</param>
    /// <param name="target">The integer value to locate within the array.</param>
    /// <returns>
    ///     The index of <paramref name="target" /> in <paramref name="nums" /> if found; otherwise, -1.
    /// </returns>
    /// <remarks>
    ///     The method assumes <paramref name="nums" /> is sorted in ascending order.
    ///     <para>
    ///         <b>Time Complexity:</b> O(log n), where n is the length of <paramref name="nums" />.
    ///     </para>
    ///     <para>
    ///         <b>Space Complexity:</b> O(1), as the algorithm uses a constant amount of extra space.
    ///     </para>
    /// </remarks>
    public static int RunBinarySearch(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;

        while (l <= r) {
            // Avoids overflow, slightly faster than division
            var mid = l + ((r - l) >> 1);
            var midVal = nums[mid];

            if (target == midVal) {
                return mid;
            }

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