namespace Leetcode.CodeTemplates;

/// <summary>
///     Provides utility methods for working with overlapping intervals.
/// </summary>
public abstract class OverlappingIntervals {
    /// <summary>
    ///     Inserts a new interval into a list of non-overlapping intervals and merges if necessary.
    /// </summary>
    /// <param name="intervals">A 2D array of non-overlapping intervals sorted by start time.</param>
    /// <param name="newInterval">The interval to insert and merge if overlapping.</param>
    /// <returns>
    ///     A new 2D array of intervals after inserting and merging the new interval.
    /// </returns>
    /// <remarks>
    ///     Time Complexity: O(N), where N is the number of intervals.
    ///     Space Complexity: O(N), for storing the result.
    /// </remarks>
    public static int[][] InsertInterval(int[][] intervals, int[] newInterval) {
        var n = intervals.Length;
        var result = new List<int[]>(n + 1);
        var i = 0;

        // Add all intervals ending before newInterval starts
        while (i < n && intervals[i][1] < newInterval[0]) {
            result.Add(intervals[i++]);
        }

        // Merge all overlapping intervals with newInterval
        while (i < n && intervals[i][0] <= newInterval[1]) {
            newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
            newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
            i++;
        }

        result.Add(newInterval);

        // Add the remaining intervals
        while (i < n) {
            result.Add(intervals[i++]);
        }

        return result.ToArray();
    }

    /// <summary>
    ///     Merges all overlapping intervals in the given array of intervals.
    ///     The input array is sorted and merged intervals are computed, but the result is not returned or stored.
    /// </summary>
    /// <param name="intervals">A 2D array where each sub-array represents an interval [start, end].</param>
    /// <remarks>
    ///     Time Complexity: O(N log N), where N is the number of intervals (due to sorting).
    ///     Space Complexity: O(N), for storing the merged intervals.
    /// </remarks>
    public static void MergeOverlappingIntervals(int[][] intervals) {
        var n = intervals.Length;
        if (n <= 1) {
            return;
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var last = 0; // Points to the last merged interval
        for (var i = 1; i < n; i++) {
            if (intervals[last][1] < intervals[i][0]) {
                last++;
                intervals[last][0] = intervals[i][0];
                intervals[last][1] = intervals[i][1];
            }
            else {
                // Merge intervals
                intervals[last][1] = Math.Max(intervals[last][1], intervals[i][1]);
            }
        }
    }

    /// <summary>
    ///     Sorts the given array of intervals in-place by their start values.
    /// </summary>
    /// <param name="intervals">A 2D array where each sub-array represents an interval [start, end].</param>
    /// <remarks>
    ///     Time Complexity: O(N log N), where N is the number of intervals.
    ///     Space Complexity: O(1), as sorting is done in-place.
    /// </remarks>
    public static void Sort(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
    }
}