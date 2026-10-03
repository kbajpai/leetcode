namespace Leetcode {
    public abstract class FindKthLargest {
        /// <summary>
        ///     Finds the kth largest element in an unsorted array.
        ///     LeetCode Problem #215: Kth Largest Element in an Array
        /// </summary>
        /// <param name="nums">The input array of integers</param>
        /// <param name="k">The position of the largest element to find (1-indexed)</param>
        /// <returns>The kth largest element in the array</returns>
        /// <remarks>
        ///     Algorithm: Min-Heap (Priority Queue) approach
        ///     Strategy:
        ///     1. Maintain a min-heap of size k
        ///     2. The root of the min-heap will always be the smallest among the k largest elements
        ///     3. After processing all elements, the root is the kth largest element
        ///     Time Complexity: O(n log k) where n is the length of the array
        ///     - We iterate through n elements
        ///     - Each heap operation (insert/remove) takes O(log k)
        ///     Space Complexity: O(k) for storing the heap
        ///     Example: nums = [3,2,1,5,6,4], k = 2
        ///     - We want the 2nd largest element
        ///     - Min-heap will maintain the 2 largest elements: [5, 6]
        ///     - The root (minimum of these 2) is 5, which is the 2nd largest overall
        /// </remarks>
        public static int FindKthLargestElement(int[] nums, int k) {
            // Use a min-heap (PriorityQueue with default comparer for ascending order)
            // The heap will store at most k elements
            var minHeap = new PriorityQueue<int, int>();

            foreach (var num in nums) {
                // Add current element to the heap
                minHeap.Enqueue(num, num);

                // If heap size exceeds k, remove the smallest element
                // This ensures we only keep the k largest elements seen so far
                if (minHeap.Count > k) {
                    minHeap.Dequeue();
                }
            }

            // The root of the min-heap (smallest of the k largest elements)
            // is the kth largest element in the entire array
            return minHeap.Peek();
        }
    }
}