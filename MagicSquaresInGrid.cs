namespace LeetCode.MagicSquaresInGrid;

public class Solution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        bool IsMagic(int i, int j)
        {
            bool[] once = new bool[10];
            int[] rowSum = new int[3];
            int[] colSum = new int[3];

            for (int a = i - 1; a <= i + 1; a++)
            {
                for (int b = j - 1; b <= j + 1; b++)
                {
                    int x = grid[a][b];
                    if (x < 1 || x > 9) return false;
                    rowSum[a - i + 1] += x;
                    colSum[b - j + 1] += x;
                    if (once[x]) return false; // it's not unique
                    once[x] = true;
                }
            }

            for (int b = 1; b <= 9; b++)
            {
                if (!once[b]) return false;
            }

            foreach (var sum in rowSum)
            {
                if (sum != 15) return false;
            }
            foreach (var sum in colSum)
            {
                if (sum != 15) return false;
            }

            return grid[i - 1][j - 1] + grid[i + 1][j + 1] == 10 &&
                   grid[i + 1][j - 1] + grid[i - 1][j + 1] == 10;
        }

        int r = grid.Length;
        int c = grid[0].Length;
        if (r < 3 || c < 3) return 0;

        int cnt = 0;
        for (int i = 1; i < r - 1; i++)
        {
            for (int j = 1; j < c - 1; j++)
            {
                if (grid[i][j] == 5 && IsMagic(i, j))
                {
                    cnt++;
                }
            }
        }
        return cnt;
    }
}
