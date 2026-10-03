using Leetcode.CodeTemplates;
using Xunit;

namespace LeetcodeTests;

public class LRUCacheTests {
    [Fact]
    public void Get_KeyDoesNotExist_ReturnsMinusOne() {
        // Arrange
        var cache = new LRUCache(2);

        // Act & Assert
        Assert.Equal(-1, cache.Get(1));
    }

    [Fact]
    public void Get_MovesAccessedItemToHead() {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        // Cache is { (1,1), (2,2) } - 1 is LRU

        // Act
        cache.Get(1); // Access 1, moves it to MRU
        // Cache is { (2,2), (1,1) } - 2 is LRU
        cache.Put(3, 3);
        // Cache is { (1,1), (3,3) } - 1 is LRU, 2 evicted

        // Assert
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(3, cache.Get(3));
    }

    [Fact]
    public void LRUCache_CapacityOne_EvictsCorrectly() {
        // Arrange
        var cache = new LRUCache(1);

        // Act & Assert
        cache.Put(1, 1);
        Assert.Equal(1, cache.Get(1));
        cache.Put(2, 2);
        Assert.Equal(-1, cache.Get(1)); // 1 should be evicted
        Assert.Equal(2, cache.Get(2));
    }

    [Fact]
    public void LRUCache_CapacityZero_DoesNothing() {
        // Arrange
        var cache = new LRUCache(0);

        // Act
        cache.Put(1, 1);

        // Assert
        Assert.Equal(-1, cache.Get(1));
    }

    [Fact]
    public void LRUCache_LeetCodeExample1_ReturnsCorrectSequence() {
        // Arrange
        var cache = new LRUCache(2);

        // Act & Assert
        cache.Put(1, 1);
        cache.Put(2, 2); // cache is { (1,1), (2,2) }
        Assert.Equal(1, cache.Get(1)); // returns 1, cache is { (2,2), (1,1) }
        cache.Put(3, 3); // evicts key 2, cache is { (1,1), (3,3) }
        Assert.Equal(-1, cache.Get(2)); // returns -1 (not found)
        cache.Put(4, 4); // evicts key 1, cache is { (3,3), (4,4) }
        Assert.Equal(-1, cache.Get(1)); // returns -1 (not found)
        Assert.Equal(3, cache.Get(3)); // returns 3, cache is { (4,4), (3,3) }
        Assert.Equal(4, cache.Get(4)); // returns 4, cache is { (3,3), (4,4) }
    }

    [Fact]
    public void LRUCache_MultiplePutsWithoutGet_MaintainsLRUOrder() {
        // Arrange
        var cache = new LRUCache(3);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(3, 3);
        // Cache: (1,1), (2,2), (3,3) - 1 is LRU

        // Act & Assert
        Assert.Equal(1, cache.Get(1)); // (2,2), (3,3), (1,1) - 2 is LRU
        cache.Put(4, 4); // (3,3), (1,1), (4,4) - 2 evicted

        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(4, cache.Get(4));
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(3, cache.Get(3));
    }

    [Fact]
    public void Put_EvictionWhenCapacityExceeded() {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        // Cache is { (1,1), (2,2) } - 1 is LRU

        // Act
        cache.Put(3, 3);
        // Cache is { (2,2), (3,3) } - 2 is LRU, 1 evicted

        // Assert
        Assert.Equal(-1, cache.Get(1)); // 1 should be gone
        Assert.Equal(2, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }

    [Fact]
    public void Put_Get_BasicFunctionality() {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);

        // Act & Assert
        Assert.Equal(2, cache.Get(2));
        Assert.Equal(1, cache.Get(1));
    }

    [Fact]
    public void Put_UpdateExistingKey_MovesToHead() {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        // Cache is { (1,1), (2,2) } - 1 is LRU

        // Act
        cache.Put(1, 100); // Update 1, moves it to MRU
        // Cache is { (2,2), (1,100) } - 2 is LRU
        cache.Put(3, 3);
        // Cache is { (1,100), (3,3) } - 1 is LRU, 2 evicted

        // Assert
        Assert.Equal(-1, cache.Get(2)); // 2 should be gone
        Assert.Equal(100, cache.Get(1));
        Assert.Equal(3, cache.Get(3));
    }
}