namespace LeetCode.DeleteColumnstoMakeSortedIII;

public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int rows = strs.Length;
        int cols = strs[0].Length;

        int[] dp = new int[cols];
        Array.Fill(dp, 1);

        int maxLen = 1;

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < j; i++)
            {
                if (IsValid(strs, i, j, rows))
                {
                    dp[j] = Math.Max(dp[j], dp[i] + 1);
                }
            }
            maxLen = Math.Max(maxLen, dp[j]);
        }

        return cols - maxLen;
    }

    private bool IsValid(string[] strs, int c1, int c2, int rows)
    {
        for (int r = 0; r < rows; r++)
        {
            if (strs[r][c1] > strs[r][c2])
                return false;
        }
        return true;
    }
}