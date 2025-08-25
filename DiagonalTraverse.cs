namespace LeetCode.DiagonalTraverse;

public class Solution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat == null || mat.Length == 0) return new int[0];

        int N = mat.Length;
        int M = mat[0].Length;

        int[] result = new int[N * M];
        int row = 0, col = 0;
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = mat[row][col];
            if ((row + col) % 2 == 0)
            {
                if (col == M - 1) { row++; }
                else if (row == 0) { col++; }
                else { row--; col++; }
            }
            else
            {
                if (row == N - 1) { col++; }
                else if (col == 0) { row++; }
                else { row++; col--; }
            }
        }

        return result;
    }
}