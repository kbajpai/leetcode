namespace Leetcode;

public class DiagonalTraverse {
    public int[] FindDiagonalOrder(int[][] mat) {
        var rows = mat.Length;
        var cols = mat[0].Length;
        var result = new int[rows * cols];

        int row = 0, col = 0, idx = 0;
        var up = true;

        while (idx < result.Length) {
            result[idx++] = mat[row][col];

            if (up) {
                if (col == cols - 1) {
                    row++;
                    up = false;
                }
                else if (row == 0) {
                    col++;
                    up = false;
                }
                else {
                    row--;
                    col++;
                }
            }
            else {
                if (row == rows - 1) {
                    col++;
                    up = true;
                }
                else if (col == 0) {
                    row++;
                    up = true;
                }
                else {
                    row++;
                    col--;
                }
            }
        }

        return result;
    }
}