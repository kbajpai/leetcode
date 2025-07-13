# Leetcode

## Table of Contents

1. **Prefix Sum**
   - [0303. Range Sum Query - Immutable](#0303-range-sum-query-immutable)
   - [0525. Contiguous Array](#0525-contiguous-array)
   - [0560. Subarray Sum Equals K](#0560-subarray-sum-equals-k)

2. **Two Pointers**
   - [0167. Two Sum II - Input Array is Sorted](#0167-two-sum-ii-input-array-is-sorted)
   - [0015. 3 Sum](#0015-3-sum)
   - [0011. Container with Most Water](#0011-container-with-most-water)

3. **Sliding Window**
   - [0643. Maximum Average Subarray I](#0643-maximum-average-subarray-i)
   - [0003. Longest Substring Without Repeating Characters](#0003-longest-substring-without-repeating-characters)
   - [0076. Minimum Window Substring](#0076-minimum-window-substring)

4. **Fast and Slow Pointers**
   - [0141. Linked List Cycle](#0141-linked-list-cycle)
   - [0202. Happy Number](#0202-happy-number)
   - [0287. Find the Duplicate Number](#0287-find-the-duplicate-number)

5. **Linked List In-Place Reversal**
   - [0206. Reverse Linked List](#0206-reverse-linked-list)
   - [0092. Reverse Linked List II](#0092-reverse-linked-list-ii)
   - [0024. Swap Nodes in Pairs](#0024-swap-nodes-in-pairs)

6. **Monotonic Stack**
   - [0496. Next Greater Element I](#0496-next-greater-element-i)
   - [0739. Daily Temperatures](#0739-daily-temperatures)
   - [0084. Largest Rectangle in Histogram](#0084-largest-rectangle-in-histogram)

7. **Top K Elements (Min/Max Heap)**
   - [0215. Kth Largest Element in an Array](#0215-kth-largest-element-in-an-array)
   - [0347. Top K Frequent Elements](#0347-top-k-frequent-elements)
   - [0373. Find K Pairs with Smallest Sums](#0373-find-k-pairs-with-smallest-sums)

8. **Overlapping Intervals**
   - [0056. Merge Intervals](#0056-merge-intervals)
   - [0057. Insert Interval](#0057-insert-interval)
   - [0435. Non-overlapping Intervals](#0435-non-overlapping-intervals)

9. **Modified Binary Search**
   - [0033. Search in Rotated Sorted Array](#0033-search-in-rotated-sorted-array)
   - [0153. Find Minimum in Rotated Sorted Array](#0153-find-minimum-in-rotated-sorted-array)
   - [0240. Search a 2D Matrix II](#0240-search-a-2d-matrix-ii)

10. **Binary Tree Traversal**
    - [0257. Binary Tree Paths](#0257-binary-tree-paths)
    - [0230. Kth Smallest Element in a BST](#0230-kth-smallest-element-in-a-bst)
    - [0124. Binary Tree Maximum Path Sum](#0124-binary-tree-maximum-path-sum)
    - [0107. Binary Tree Level Order Traversal II](#0107-binary-tree-level-order-traversal-ii)

11. **Depth First Search (DFS)**
    - [0133. Clone Graph](#0133-clone-graph)
    - [0113. Path Sum II](#0113-path-sum-ii)
    - [0210. Course Schedule II](#0210-course-schedule-ii)

12. **Breadth First Search (BFS)**
    - [0102. Binary Tree Level Order Traversal](#0102-binary-tree-level-order-traversal)
    - [0994. Rotting Oranges](#0994-rotting-oranges)
    - [0127. Word Ladder](#0127-word-ladder)

13. **Matrix Traversal**
    - [0733. Flood Fill](#0733-flood-fill)
    - [0200. Number of Islands](#0200-number-of-islands)
    - [0130. Surrounded Regions](#0130-surrounded-regions)

14. **Backtracking**
    - [0046. Permutations](#0046-permutations)
    - [0078. Subsets](#0078-subsets)
    - [0051. N-Queens](#0051-n-queens)

15. **Dynamic Programming**
    - [0070. Climbing Stairs](#0070-climbing-stairs)
    - [0322. Coin Change](#0322-coin-change)
    - [0300. Longest Increasing Subsequence](#0300-longest-increasing-subsequence)
    - [0416. Partition Equal Subset Sum](#0416-partition-equal-subset-sum)
    - [0312. Burst Balloons](#0312-burst-balloons)
    - [1143. Longest Common Subsequence](#1143-longest-common-subsequence)


<a id='0303-range-sum-query-immutable'>0303. Range Sum Query Immutable</a>
```csharp
public class PrefixSum
{
    /// <summary>
    /// Leetcode 303. Range Sum Query - Immutable
    /// Given an integer array nums, handle multiple queries of the following type:
    /// Calculate the sum of the elements of nums between indices left and right inclusive.
    /// </summary>
    public class NumArray
    {
        private readonly int[] prefixSums;

        public NumArray(int[] nums)
        {
            prefixSums = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSums[i + 1] = prefixSums[i] + nums[i];
            }
        }

        public int SumRange(int left, int right)
        {
            return prefixSums[right + 1] - prefixSums[left];
        }
    }
}
```