using Leetcode;
using Xunit;

namespace LeetcodeTests {
    public class SpiralMatrixTests {
        [Fact]
        public void SpiralOrder_RectangularMatrix_ReturnsClockwiseSpiral() {
            // Arrange
            var matrix = new[] {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 6, 7, 8 },
                new[] { 9, 10, 11, 12 }
            };
            // Act
            var result = SpiralMatrix.SpiralOrder(matrix);

            // Assert
            Assert.Equal([1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7], result);
        }

        [Fact]
        public void SpiralOrder_SingleElement_ReturnsElement() {
            // Arrange
            var matrix = new[] { new[] { 42 } };
            // Act
            var result = SpiralMatrix.SpiralOrder(matrix);

            // Assert
            Assert.Equal([42], result);
        }

        [Fact]
        public void SpiralOrder_ThreeByThreeMatrix_ReturnsClockwiseSpiral() {
            // Arrange
            var matrix = new[] {
                new[] { 1, 2, 3 },
                [4, 5, 6],
                [7, 8, 9]
            };
            // Act
            var result = SpiralMatrix.SpiralOrder(matrix);

            // Assert
            Assert.Equal([1, 2, 3, 6, 9, 8, 7, 4, 5], result);
        }
    }
}