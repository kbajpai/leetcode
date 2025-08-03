using Leetcode.CodeTemplates;
using Xunit;

namespace LeetcodeTests;

public class OverlappingIntervalsTests {
    [Fact]
    public void InsertInterval_EmptyIntervals_InsertsNewInterval() {
        var intervals = Array.Empty<int[]>();
        var newInterval = new[] { 2, 5 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Single(result);
        Assert.Equal(new[] { 2, 5 }, result[0]);
    }

    [Fact]
    public void InsertInterval_NewIntervalAfterAll_Appends() {
        var intervals = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
        var newInterval = new[] { 5, 6 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 3, 4 }, result[1]);
        Assert.Equal(new[] { 5, 6 }, result[2]);
    }

    [Fact]
    public void InsertInterval_NewIntervalBeforeAll_Prepends() {
        var intervals = new[] { new[] { 5, 7 }, new[] { 8, 10 } };
        var newInterval = new[] { 1, 3 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 3 }, result[0]);
        Assert.Equal(new[] { 5, 7 }, result[1]);
        Assert.Equal(new[] { 8, 10 }, result[2]);
    }

    [Fact]
    public void InsertInterval_NewIntervalCoversAll_MergesToOne() {
        var intervals = new[] { new[] { 2, 3 }, new[] { 5, 7 }, new[] { 8, 10 } };
        var newInterval = new[] { 1, 12 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Single(result);
        Assert.Equal(new[] { 1, 12 }, result[0]);
    }

    [Fact]
    public void InsertInterval_NoOverlap_AppendsNewInterval() {
        var intervals = new[] { new[] { 1, 2 }, new[] { 5, 6 } };
        var newInterval = new[] { 7, 8 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 5, 6 }, result[1]);
        Assert.Equal(new[] { 7, 8 }, result[2]);
    }

    [Fact]
    public void InsertInterval_OverlapWithMultipleIntervals_MergesAll() {
        var intervals = new[] { new[] { 1, 2 }, new[] { 3, 5 }, new[] { 6, 7 }, new[] { 8, 10 }, new[] { 12, 16 } };
        var newInterval = new[] { 4, 8 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 3, 10 }, result[1]);
        Assert.Equal(new[] { 12, 16 }, result[2]);
    }

    [Fact]
    public void InsertInterval_OverlapWithOneInterval_MergesCorrectly() {
        var intervals = new[] { new[] { 1, 3 }, new[] { 6, 9 } };
        var newInterval = new[] { 2, 5 };
        var result = OverlappingIntervals.InsertInterval(intervals, newInterval);
        Assert.Equal(2, result.Length);
        Assert.Equal(new[] { 1, 5 }, result[0]);
        Assert.Equal(new[] { 6, 9 }, result[1]);
    }

    [Fact]
    public void MergeOverlappingIntervals_AllOverlapping_MergesToOne() {
        var intervals = new[] { new[] { 1, 4 }, new[] { 2, 5 }, new[] { 3, 6 } };
        OverlappingIntervals.MergeOverlappingIntervals(intervals);
        // The method does not return the merged result, so we cannot assert the merged output.
        // This test ensures no exception is thrown.
    }

    [Fact]
    public void MergeOverlappingIntervals_EmptyArray_NoException() {
        var intervals = Array.Empty<int[]>();
        OverlappingIntervals.MergeOverlappingIntervals(intervals);
        Assert.Empty(intervals);
    }

    [Fact]
    public void MergeOverlappingIntervals_NoOverlaps_NoChange() {
        var intervals = new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } };
        var expected = new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } };
        OverlappingIntervals.MergeOverlappingIntervals(intervals);
        Assert.Equal(expected, intervals);
    }

    [Fact]
    public void MergeOverlappingIntervals_SomeOverlapping_MergesCorrectly() {
        var intervals = new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };
        OverlappingIntervals.MergeOverlappingIntervals(intervals);
        // The method does not return the merged result, so we cannot assert the merged output.
        // This test ensures no exception is thrown.
    }

    [Fact]
    public void Sort_AlreadySorted_NoChange() {
        var intervals = new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } };
        OverlappingIntervals.Sort(intervals);
        Assert.Equal(new[] { 1, 2 }, intervals[0]);
        Assert.Equal(new[] { 3, 4 }, intervals[1]);
        Assert.Equal(new[] { 5, 6 }, intervals[2]);
    }

    [Fact]
    public void Sort_EmptyArray_NoException() {
        var intervals = Array.Empty<int[]>();
        OverlappingIntervals.Sort(intervals);
        Assert.Empty(intervals);
    }

    [Fact]
    public void Sort_SingleInterval_NoChange() {
        var intervals = new[] { new[] { 7, 8 } };
        OverlappingIntervals.Sort(intervals);
        Assert.Single(intervals);
        Assert.Equal(new[] { 7, 8 }, intervals[0]);
    }

    [Fact]
    public void Sort_SortsIntervalsByStartAscending() {
        var intervals = new[] { new[] { 5, 10 }, new[] { 1, 3 }, new[] { 2, 6 } };
        OverlappingIntervals.Sort(intervals);
        Assert.Equal(new[] { 1, 3 }, intervals[0]);
        Assert.Equal(new[] { 2, 6 }, intervals[1]);
        Assert.Equal(new[] { 5, 10 }, intervals[2]);
    }
}