using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class CloneGraphTests {
    // Create a concrete implementation for testing
    private class TestableCloneGraph : CloneGraph {
        // Concrete implementation for testing
    }

    private readonly TestableCloneGraph _cloneGraph = new();

    [Fact]
    public void RunCloneGraph_ReturnsNull_WhenInputIsNull() {
        // Act
        var result = _cloneGraph.RunCloneGraph(null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void RunCloneGraph_ClonesSingleNode_WhenGraphHasOneNode() {
        // Arrange
        var node = new Node(1);

        // Act
        var clonedNode = _cloneGraph.RunCloneGraph(node);

        // Assert
        Assert.NotNull(clonedNode);
        Assert.Equal(1, clonedNode.Val);
        Assert.Empty(clonedNode.Neighbors);
        Assert.NotSame(node, clonedNode); // Different object references
    }

    [Fact]
    public void RunCloneGraph_ClonesConnectedNodes_WhenGraphHasTwoConnectedNodes() {
        // Arrange - Create graph: 1 <-> 2
        var node1 = new Node(1);
        var node2 = new Node(2);
        node1.Neighbors.Add(node2);
        node2.Neighbors.Add(node1);

        // Act
        var clonedNode1 = _cloneGraph.RunCloneGraph(node1);

        // Assert
        Assert.NotNull(clonedNode1);
        Assert.Equal(1, clonedNode1.Val);
        Assert.Single(clonedNode1.Neighbors);
        
        var clonedNode2 = clonedNode1.Neighbors[0];
        Assert.Equal(2, clonedNode2.Val);
        Assert.Single(clonedNode2.Neighbors);
        Assert.Same(clonedNode1, clonedNode2.Neighbors[0]); // Properly connected back

        // Verify original and cloned are different objects
        Assert.NotSame(node1, clonedNode1);
        Assert.NotSame(node2, clonedNode2);
    }

    [Fact]
    public void RunCloneGraph_ClonesLinearGraph_WhenGraphIsChain() {
        // Arrange - Create chain: 1 -> 2 -> 3
        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        node1.Neighbors.Add(node2);
        node2.Neighbors.Add(node3);

        // Act
        var clonedNode1 = _cloneGraph.RunCloneGraph(node1);

        // Assert
        Assert.NotNull(clonedNode1);
        Assert.Equal(1, clonedNode1.Val);
        Assert.Single(clonedNode1.Neighbors);

        var clonedNode2 = clonedNode1.Neighbors[0];
        Assert.Equal(2, clonedNode2.Val);
        Assert.Single(clonedNode2.Neighbors);

        var clonedNode3 = clonedNode2.Neighbors[0];
        Assert.Equal(3, clonedNode3.Val);
        Assert.Empty(clonedNode3.Neighbors);

        // Verify all are different objects
        Assert.NotSame(node1, clonedNode1);
        Assert.NotSame(node2, clonedNode2);
        Assert.NotSame(node3, clonedNode3);
    }

    [Fact]
    public void RunCloneGraph_ClonesComplexGraph_WhenGraphHasMultipleConnections() {
        // Arrange - Create graph where node 1 connects to 2 and 4, node 2 connects to 1 and 3, etc.
        // Graph structure:
        //   1 --- 2
        //   |     |
        //   4 --- 3
        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        var node4 = new Node(4);

        node1.Neighbors.Add(node2);
        node1.Neighbors.Add(node4);
        node2.Neighbors.Add(node1);
        node2.Neighbors.Add(node3);
        node3.Neighbors.Add(node2);
        node3.Neighbors.Add(node4);
        node4.Neighbors.Add(node1);
        node4.Neighbors.Add(node3);

        // Act
        var clonedNode1 = _cloneGraph.RunCloneGraph(node1);

        // Assert
        Assert.NotNull(clonedNode1);
        Assert.Equal(1, clonedNode1.Val);
        Assert.Equal(2, clonedNode1.Neighbors.Count);

        // Find cloned nodes by their values
        var clonedNodes = new Dictionary<int, Node> { { 1, clonedNode1 } };
        var visited = new HashSet<Node> { clonedNode1 };
        var queue = new Queue<Node>();
        queue.Enqueue(clonedNode1);

        while (queue.Count > 0) {
            var current = queue.Dequeue();
            foreach (var neighbor in current.Neighbors) {
                if (!visited.Contains(neighbor)) {
                    visited.Add(neighbor);
                    clonedNodes[neighbor.Val] = neighbor;
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Verify all 4 nodes are cloned
        Assert.Equal(4, clonedNodes.Count);
        Assert.Contains(1, clonedNodes.Keys);
        Assert.Contains(2, clonedNodes.Keys);
        Assert.Contains(3, clonedNodes.Keys);
        Assert.Contains(4, clonedNodes.Keys);

        // Verify connections are preserved
        var clone1 = clonedNodes[1];
        var clone2 = clonedNodes[2];
        var clone3 = clonedNodes[3];
        var clone4 = clonedNodes[4];

        Assert.Contains(clone2, clone1.Neighbors);
        Assert.Contains(clone4, clone1.Neighbors);
        Assert.Contains(clone1, clone2.Neighbors);
        Assert.Contains(clone3, clone2.Neighbors);
        Assert.Contains(clone2, clone3.Neighbors);
        Assert.Contains(clone4, clone3.Neighbors);
        Assert.Contains(clone1, clone4.Neighbors);
        Assert.Contains(clone3, clone4.Neighbors);

        // Verify they are different objects from originals
        Assert.NotSame(node1, clone1);
        Assert.NotSame(node2, clone2);
        Assert.NotSame(node3, clone3);
        Assert.NotSame(node4, clone4);
    }

    [Fact]
    public void RunCloneGraph_HandlesSelfLoop_WhenNodePointsToItself() {
        // Arrange - Create node that points to itself
        var node = new Node(1);
        node.Neighbors.Add(node);

        // Act
        var clonedNode = _cloneGraph.RunCloneGraph(node);

        // Assert
        Assert.NotNull(clonedNode);
        Assert.Equal(1, clonedNode.Val);
        Assert.Single(clonedNode.Neighbors);
        Assert.Same(clonedNode, clonedNode.Neighbors[0]); // Points to itself
        Assert.NotSame(node, clonedNode); // Different object from original
    }

    [Fact]
    public void RunCloneGraph_ClonesGraphWithDuplicateValues_WhenMultipleNodesHaveSameValue() {
        // Arrange - Create graph where multiple nodes have the same value
        var node1 = new Node(1);
        var node2 = new Node(1); // Same value as node1
        var node3 = new Node(2);
        
        node1.Neighbors.Add(node2);
        node1.Neighbors.Add(node3);
        node2.Neighbors.Add(node1);
        node3.Neighbors.Add(node1);

        // Act
        var clonedNode1 = _cloneGraph.RunCloneGraph(node1);

        // Assert
        Assert.NotNull(clonedNode1);
        Assert.Equal(1, clonedNode1.Val);
        Assert.Equal(2, clonedNode1.Neighbors.Count);

        // Verify both neighbors exist and have correct values
        var neighborValues = clonedNode1.Neighbors.Select(n => n.Val).OrderBy(v => v).ToArray();
        Assert.Equal([1, 2], neighborValues);

        // Verify they are all different objects from originals
        Assert.NotSame(node1, clonedNode1);
        Assert.All(clonedNode1.Neighbors, neighbor => {
            Assert.True(neighbor != node1 && neighbor != node2 && neighbor != node3);
        });
    }

    [Fact]
    public void RunCloneGraph_HandlesMultipleCalls_WhenCalledRepeatedlyOnSameInstance() {
        // Arrange
        var node1 = new Node(1);
        var node2 = new Node(2);
        node1.Neighbors.Add(node2);
        node2.Neighbors.Add(node1);

        // Act - Call multiple times
        var firstClone = _cloneGraph.RunCloneGraph(node1);
        var secondClone = _cloneGraph.RunCloneGraph(node1);

        // Assert - Each call should produce independent clones
        Assert.NotNull(firstClone);
        Assert.NotNull(secondClone);
        Assert.NotSame(firstClone, secondClone);
        Assert.Equal(firstClone.Val, secondClone.Val);
        Assert.Equal(firstClone.Neighbors.Count, secondClone.Neighbors.Count);
    }

    [Fact]
    public void RunCloneGraph_PreservesGraphStructure_WhenGraphIsComplete() {
        // Arrange - Create a complete graph with 3 nodes (each connected to every other)
        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);

        node1.Neighbors.Add(node2);
        node1.Neighbors.Add(node3);
        node2.Neighbors.Add(node1);
        node2.Neighbors.Add(node3);
        node3.Neighbors.Add(node1);
        node3.Neighbors.Add(node2);

        // Act
        var clonedNode1 = _cloneGraph.RunCloneGraph(node1);

        // Assert
        Assert.NotNull(clonedNode1);
        
        // Collect all cloned nodes
        var allClonedNodes = new HashSet<Node>();
        var queue = new Queue<Node>();
        queue.Enqueue(clonedNode1);
        allClonedNodes.Add(clonedNode1);

        while (queue.Count > 0) {
            var current = queue.Dequeue();
            foreach (var neighbor in current.Neighbors) {
                if (!allClonedNodes.Contains(neighbor)) {
                    allClonedNodes.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Verify we have exactly 3 nodes
        Assert.Equal(3, allClonedNodes.Count);

        // Verify each node has exactly 2 neighbors (complete graph property)
        Assert.All(allClonedNodes, node => Assert.Equal(2, node.Neighbors.Count));

        // Verify values are 1, 2, 3
        var values = allClonedNodes.Select(n => n.Val).OrderBy(v => v).ToArray();
        Assert.Equal([1, 2, 3], values);
    }
}