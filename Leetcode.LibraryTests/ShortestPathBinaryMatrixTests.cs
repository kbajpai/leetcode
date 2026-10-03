using Leetcode;
using Xunit;

namespace LeetcodeTests {
    public class ShortestPathBinaryMatrixTests {
        [Fact]
        public void EmptyGrid_ReturnsMinusOne() {
            var grid = Array.Empty<int[]>();
            Assert.Equal(-1, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void SingleCellOpen_ReturnsOne() {
            var grid = new int[][] { [0] };
            Assert.Equal(1, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void SingleCellBlocked_ReturnsMinusOne() {
            var grid = new int[][] { [1] };
            Assert.Equal(-1, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void StartBlocked_ReturnsMinusOne() {
            var grid = new int[][] {
                [1, 0],
                [0, 0]
            };
            Assert.Equal(-1, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void EndBlocked_ReturnsMinusOne() {
            var grid = new int[][] {
                [0, 0],
                [0, 1]
            };
            Assert.Equal(-1, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void TwoByTwo_AllOpen_ReturnsTwo() {
            var grid = new int[][] {
                [0, 0],
                [0, 0]
            };
            // Path: (0,0) -> (1,1) diagonal move = 2 steps
            Assert.Equal(2, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void ThreeByThree_DirectPath_ReturnsFour() {
            var grid = new int[][] {
                [0, 0, 0],
                [1, 1, 0],
                [1, 1, 0]
            };
            // Path: (0,0) -> (0,1) -> (0,2) -> (2,2) = 4 steps
            Assert.Equal(4, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void ThreeByThree_DiagonalPath_ReturnsThree() {
            var grid = new int[][] {
                [0, 1, 0],
                [0, 0, 0],
                [0, 0, 0]
            };
            // Path: (0,0) -> (1,1) -> (2,2) diagonal moves = 3 steps
            Assert.Equal(3, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void NoPath_ReturnsMinusOne() {
            var grid = new int[][] {
                [0, 1, 1],
                [1, 1, 1],
                [1, 1, 0]
            };
            Assert.Equal(-1, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }

        [Fact]
        public void LargerGrid_ValidPath_ReturnsCorrectLength() {
            var grid = new int[][] {
                [0, 0, 0, 0],
                [1, 1, 0, 1],
                [1, 1, 0, 1],
                [1, 1, 0, 0]
            };
            Assert.Equal(5, ShortestPathBinaryMatrix.RunShortestPathBinaryMatrix(grid));
        }
    }
}