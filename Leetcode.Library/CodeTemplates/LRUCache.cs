using System.Runtime.CompilerServices;

namespace Leetcode.CodeTemplates;

/*
Pseudocode / Plan (detailed):
- Implement an LRU cache with O(1) get and put operations using:
  - A dictionary mapping key -> node for fast lookups.
  - A doubly-linked list to maintain recency order:
    - Head is most recently used (MRU).
    - Tail is least recently used (LRU).
- Node structure contains: key, value, prev, next.
- Fields:
  - int _capacity
  - Dictionary<int, Node> _map
  - Node _head, _tail (sentinel/dummy nodes for easier operations)
- Constructor:
  - Initialize capacity, map, dummy head and tail and link them.
- Get(key):
  - If key not in map return -1.
  - Otherwise move node to head (mark MRU) and return value.
- Put(key, value):
  - If capacity <= 0: ignore.
  - If key exists:
    - Update node value and move to head.
  - Else:
    - If at capacity:
      - Remove tail.prev (LRU node) from list and map.
    - Create new node, add to map and insert at head.
- Helper methods:
  - AddToHead(node): insert node right after dummy head.
  - RemoveNode(node): unlink node from list.
  - MoveToHead(node): RemoveNode + AddToHead.
*/

public sealed class LRUCache {
    private readonly int _capacity;
    private readonly Dictionary<int, Node> _map;
    private readonly Node _head; // Most recently used
    private readonly Node _tail; // Least recently used

    public LRUCache(int capacity) {
        _capacity = capacity;
        _map = new Dictionary<int, Node>(capacity);
        _head = new Node();
        _tail = new Node();
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int key) {
        if (!_map.TryGetValue(key, out var node)) {
            return -1;
        }

        MoveToHead(node);
        return node.Value;
    }

    public void Put(int key, int value) {
        if (_capacity <= 0) {
            return;
        }

        if (_map.TryGetValue(key, out var node)) {
            node.Value = value;
            MoveToHead(node);
        }
        else {
            if (_map.Count >= _capacity) {
                // Evict the least recently used item
                var lru = _tail.Prev!;
                RemoveNode(lru);
                _map.Remove(lru.Key);
            }

            var newNode = new Node(key, value);
            AddToHead(newNode);
            _map.Add(key, newNode);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddToHead(Node node) {
        node.Prev = _head;
        node.Next = _head.Next;
        _head.Next!.Prev = node;
        _head.Next = node;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void MoveToHead(Node node) {
        RemoveNode(node);
        AddToHead(node);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RemoveNode(Node node) {
        // Safe due to sentinel nodes _head and _tail.
        // A real node always has non-null Prev and Next.
        node.Prev!.Next = node.Next;
        node.Next!.Prev = node.Prev;
    }

    private sealed class Node(int key = 0, int value = 0) {
        public readonly int Key = key;
        public int Value = value;
        public Node? Prev;
        public Node? Next;
    }
}