namespace Leetcode;

public abstract class FundCircleNum {
    public static int FindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        if (n == 1) return 1;

        var seen = new bool[n];
        var provinces = 0;

        for (var i = 0; i < n; i++) {
            if (!seen[i]) {
                provinces++;
                DFS(i);
            }
        }

        return provinces;

        void DFS(int i) {
            seen[i] = true;
            for (var j = 0; j < n; j++) {
                if (isConnected[i][j] == 1 && !seen[j]) {
                    DFS(j);
                }
            }
        }
    }
}