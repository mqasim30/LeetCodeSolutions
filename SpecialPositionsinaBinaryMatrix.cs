namespace LeetCode.SpecialPositionsinaBinaryMatrix;

public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int n = mat.Length;
        int m = mat[0].Length;

        int[] rowsT = new int[n]; // Stores the total of each row
        int[] columnT = new int[m]; // Stores the total of each column

        // Sum up rows and columns
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < m; y++)
            {
                rowsT[x] += mat[x][y];
                columnT[y] += mat[x][y];
            }
        }

        // Check which cells are special
        int specialCells = 0;
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < m; y++)
            {
                if (rowsT[x] == 1 && columnT[y] == 1 && mat[x][y] == 1) specialCells++;
            }
        }

        return specialCells;
    }
}