namespace Leetcode {
    public abstract class SpiralMatrix {
        public static IList<int> SpiralOrder(int[][] matrix) {
            if (matrix.Length == 0 || matrix[0].Length == 0) {
                return [];
            }

            var rows = matrix.Length;
            var cols = matrix[0].Length;

            var result = new List<int>(rows * cols);
            var top = 0;
            var bottom = rows - 1;
            var left = 0;
            var right = cols - 1;

            while (top <= bottom && left <= right) {
                for (var col = left; col <= right; col++) {
                    result.Add(matrix[top][col]);
                }
                top++;

                for (var row = top; row <= bottom; row++) {
                    result.Add(matrix[row][right]);
                }
                right--;

                if (top <= bottom) {
                    for (var col = right; col >= left; col--) {
                        result.Add(matrix[bottom][col]);
                    }
                    bottom--;
                }

                if (left <= right) {
                    for (var row = bottom; row >= top; row--) {
                        result.Add(matrix[row][left]);
                    }
                    left++;
                }
            }

            return result;
        }
    }
}