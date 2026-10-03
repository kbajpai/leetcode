namespace Leetcode;

public class CountDays {
    public int RunCountDays(int days, int[][] meetings) {
        // Sort meetings by start time for efficient merging
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        // Merge overlapping intervals to avoid redundant calculations
        var mergedIntervals = new List<int[]>();

        foreach (var meeting in meetings) {
            var start = meeting[0];
            var end = meeting[1];

            if (mergedIntervals.Count == 0 || mergedIntervals[^1][1] < start - 1) {
                // No overlap with previous interval
                mergedIntervals.Add([start, end]);
            }
            else {
                // Merge with previous interval
                mergedIntervals[^1][1] = Math.Max(mergedIntervals[^1][1], end);
            }
        }

        // Calculate total covered days from merged intervals
        long coveredDays = 0;
        foreach (var interval in mergedIntervals) {
            coveredDays += interval[1] - interval[0] + 1;
        }

        return (int)(days - coveredDays);
    }
}