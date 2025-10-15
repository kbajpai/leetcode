namespace Leetcode.DataStructures.Heaps {
    /// <summary>
    ///     A Max Heap data structure where the parent node is always greater than or equal to its children.
    ///     This implementation uses a generic list as the underlying storage and maintains the heap property
    ///     through heapify operations.
    /// </summary>
    /// <remarks>
    ///     Time Complexities:
    ///     - Insert: O(log n)
    ///     - ExtractMax: O(log n)
    ///     - Peek: O(1)
    ///     - Heapify: O(n)
    ///     Space Complexity: O(n)
    ///     A Max Heap is a complete binary tree where each parent node has a value greater than or equal
    ///     to its children. This property makes it ideal for:
    ///     - Priority queues (highest priority first)
    ///     - Heap sort algorithm
    ///     - Finding the k largest elements
    ///     - Scheduling algorithms
    ///     Example Usage:
    ///     <code>
    /// var maxHeap = new MaxHeap();
    /// maxHeap.Insert(10);
    /// maxHeap.Insert(20);
    /// maxHeap.Insert(5);
    /// maxHeap.Insert(30);
    /// 
    /// Console.WriteLine(maxHeap.Peek());        // Output: 30
    /// Console.WriteLine(maxHeap.ExtractMax());  // Output: 30
    /// Console.WriteLine(maxHeap.Peek());        // Output: 20
    /// </code>
    /// </remarks>
    public class MaxHeap {
        // Create MaxHeap using PriorityQueue
        private readonly PriorityQueue<int, int> _maxHeap = new();

        // Insert elements (negate for max behavior)
        public void Insert(int value) {
            _maxHeap.Enqueue(value, -value);
        }

        // Extracts the maximum element from the heap
        public int ExtractMax() {
            return _maxHeap.Dequeue();
        }

        // Returns the maximum element without removing it
        public int Peek() {
            return _maxHeap.Count > 0 ? _maxHeap.EnsureCapacity(1) : throw new InvalidOperationException("Heap is empty.");
        }

        // Gets the count of elements in the heap
        public int Count => _maxHeap.Count;

        // Clears the heap
        public void Clear() {
            _maxHeap.Clear();
        }
    }
}