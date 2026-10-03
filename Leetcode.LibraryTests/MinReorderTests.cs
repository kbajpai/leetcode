using Leetcode;
using Xunit;

namespace LeetcodeTests;

public class MinReorderTests {
    [Fact]
    public void RunMinReorder_ComplexTree_ReturnsCorrectCount() {
        // Arrange - More complex tree structure
        var n = 7;
        var connections = new int[][] {
            [0, 1], // Wrong: 0 -> 1
            [1, 2], // Wrong: 1 -> 2
            [3, 1], // Correct: 3 -> 1 -> 0
            [1, 4], // Wrong: 1 -> 4
            [5, 4], // Correct: 5 -> 4 -> 1 -> 0
            [6, 5] // Correct: 6 -> 5 -> 4 -> 1 -> 0
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(3, result); // [0,1], [1,2], [1,4] need reversal
    }

    [Fact]
    public void RunMinReorder_EmptyConnections_ReturnsZero() {
        // Arrange
        var n = 1;
        var connections = Array.Empty<int[]>();

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_Example1_ReturnsThree() {
        // Arrange - Example 1 from LeetCode: [[0,1],[1,3],[2,3],[4,0],[4,5]]
        var n = 6;
        var connections = new int[][] {
            [0, 1], [1, 3], [2, 3], [4, 0], [4, 5]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void RunMinReorder_Example2_ReturnsTwo() {
        // Arrange - Example 2 from LeetCode: [[1,0],[1,2],[3,2],[3,4]]
        var n = 5;
        var connections = new int[][] {
            [1, 0], [1, 2], [3, 2], [3, 4]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void RunMinReorder_Example3_ReturnsZero() {
        // Arrange - Example 3 from LeetCode: [[1,0],[2,0]]
        var n = 3;
        var connections = new int[][] {
            [1, 0], [2, 0]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_InvalidCityIndices_SkipsInvalidEdges() {
        // Arrange - Mix of valid and invalid city indices
        var n = 3;
        var connections = new int[][] {
            [1, 0], // Valid - points toward 0, no reversal needed
            [-1, 2], // Invalid - negative index
            [0, 5], // Invalid - index >= n
            [2, 1] // Valid - forms path 2->1->0, no reversal needed
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result); // No edges need reversal: 1->0 and 2->1->0 are correct
    }

    [Fact]
    public void RunMinReorder_InvalidEdgeLength_SkipsInvalidEdges() {
        // Arrange - Mix of valid and invalid edges
        var n = 3;
        var connections = new int[][] {
            [1, 0], // Valid
            [1], // Invalid - too short
            [0, 2] // Valid
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(1, result); // Only [0,2] needs reversal
    }

    [Fact]
    public void RunMinReorder_LinearChainAllCorrect_ReturnsZero() {
        // Arrange - All edges point toward city 0: 3->2->1->0
        var n = 4;
        var connections = new int[][] {
            [3, 2], [2, 1], [1, 0]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_LinearChainAllWrong_ReturnsThree() {
        // Arrange - All edges point away from city 0: 0->1->2->3
        var n = 4;
        var connections = new int[][] {
            [0, 1], [1, 2], [2, 3]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void RunMinReorder_MixedDirections_ReturnsCorrectCount() {
        // Arrange - Mixed directions: some need reversal, some don't
        var n = 6;
        var connections = new int[][] {
            [1, 0], // Correct: 1 -> 0
            [0, 2], // Wrong: 0 -> 2 (needs reversal)
            [3, 1], // Correct: 3 -> 1 -> 0
            [2, 4], // Wrong: 2 -> 4 (needs reversal)
            [5, 4] // Correct: 5 -> 4 -> 2 -> 0
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(2, result); // Only [0,2] and [2,4] need reversal
    }

    [Fact]
    public void RunMinReorder_NullConnections_ReturnsZero() {
        // Arrange
        var n = 1;
        int[][]? connections = null;

        // Act
        var result = MinReorder.RunMinReorder(n, connections!);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_SingleCity_ReturnsZero() {
        // Arrange
        var n = 1;
        var connections = Array.Empty<int[]>();

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_StarPatternAllCorrect_ReturnsZero() {
        // Arrange - All edges point toward city 0 (star pattern)
        var n = 5;
        var connections = new int[][] {
            [1, 0], [2, 0], [3, 0], [4, 0]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_StarPatternAllWrong_ReturnsFour() {
        // Arrange - All edges point away from city 0 (reverse star pattern)
        var n = 5;
        var connections = new int[][] {
            [0, 1], [0, 2], [0, 3], [0, 4]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void RunMinReorder_TwoCitiesCorrectDirection_ReturnsZero() {
        // Arrange - Edge points toward city 0
        var n = 2;
        var connections = new int[][] {
            [1, 0]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorder_TwoCitiesWrongDirection_ReturnsOne() {
        // Arrange - Edge points away from city 0
        var n = 2;
        var connections = new int[][] {
            [0, 1]
        };

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunMinReorder_ZeroCities_ReturnsZero() {
        // Arrange
        var n = 0;
        var connections = Array.Empty<int[]>();

        // Act
        var result = MinReorder.RunMinReorder(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_ComplexTree_ReturnsCorrectCount() {
        // Arrange - More complex tree structure
        var n = 7;
        var connections = new int[][] {
            [0, 1], // Wrong: 0 -> 1
            [1, 2], // Wrong: 1 -> 2
            [3, 1], // Correct: 3 -> 1 -> 0
            [1, 4], // Wrong: 1 -> 4
            [5, 4], // Correct: 5 -> 4 -> 1 -> 0
            [6, 5] // Correct: 6 -> 5 -> 4 -> 1 -> 0
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(3, result); // [0,1], [1,2], [1,4] need reversal
    }

    [Fact]
    public void RunMinReorderIterative_EmptyConnections_ReturnsZero() {
        // Arrange
        var n = 1;
        var connections = Array.Empty<int[]>();

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_Example1_ReturnsThree() {
        // Arrange - Example 1 from LeetCode: [[0,1],[1,3],[2,3],[4,0],[4,5]]
        var n = 6;
        var connections = new int[][] {
            [0, 1], [1, 3], [2, 3], [4, 0], [4, 5]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void RunMinReorderIterative_Example2_ReturnsTwo() {
        // Arrange - Example 2 from LeetCode: [[1,0],[1,2],[3,2],[3,4]]
        var n = 5;
        var connections = new int[][] {
            [1, 0], [1, 2], [3, 2], [3, 4]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void RunMinReorderIterative_Example3_ReturnsZero() {
        // Arrange - Example 3 from LeetCode: [[1,0],[2,0]]
        var n = 3;
        var connections = new int[][] {
            [1, 0], [2, 0]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_LinearChainAllCorrect_ReturnsZero() {
        // Arrange - All edges point toward city 0: 3->2->1->0
        var n = 4;
        var connections = new int[][] {
            [3, 2], [2, 1], [1, 0]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_LinearChainAllWrong_ReturnsThree() {
        // Arrange - All edges point away from city 0: 0->1->2->3
        var n = 4;
        var connections = new int[][] {
            [0, 1], [1, 2], [2, 3]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void RunMinReorderIterative_MixedDirections_ReturnsCorrectCount() {
        // Arrange - Mixed directions: some need reversal, some don't
        var n = 6;
        var connections = new int[][] {
            [1, 0], // Correct: 1 -> 0
            [0, 2], // Wrong: 0 -> 2 (needs reversal)
            [3, 1], // Correct: 3 -> 1 -> 0
            [2, 4], // Wrong: 2 -> 4 (needs reversal)
            [5, 4] // Correct: 5 -> 4 -> 2 -> 0
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(2, result); // Only [0,2] and [2,4] need reversal
    }

    [Fact]
    public void RunMinReorderIterative_SingleCity_ReturnsZero() {
        // Arrange
        var n = 1;
        var connections = Array.Empty<int[]>();

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_StarPatternAllCorrect_ReturnsZero() {
        // Arrange - All edges point toward city 0 (star pattern)
        var n = 5;
        var connections = new int[][] {
            [1, 0], [2, 0], [3, 0], [4, 0]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_StarPatternAllWrong_ReturnsFour() {
        // Arrange - All edges point away from city 0 (reverse star pattern)
        var n = 5;
        var connections = new int[][] {
            [0, 1], [0, 2], [0, 3], [0, 4]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void RunMinReorderIterative_TwoCitiesCorrectDirection_ReturnsZero() {
        // Arrange - Edge points toward city 0
        var n = 2;
        var connections = new int[][] {
            [1, 0]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void RunMinReorderIterative_TwoCitiesWrongDirection_ReturnsOne() {
        // Arrange - Edge points away from city 0
        var n = 2;
        var connections = new int[][] {
            [0, 1]
        };

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void RunMinReorderIterative_ZeroCities_ReturnsZero() {
        // Arrange
        var n = 0;
        var connections = Array.Empty<int[]>();

        // Act
        var result = MinReorder.RunMinReorderIterative(n, connections);

        // Assert
        Assert.Equal(0, result);
    }
}