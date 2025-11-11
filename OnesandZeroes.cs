namespace LeetCode.OnesandZeroes;

public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[,] dp = new int[m + 1, n + 1];

        foreach (var str in strs)
        {
            int zeros = 0, ones = 0;
            foreach (var ch in str)
            {
                if (ch == '0') zeros++;
                else ones++;
            }

            for (int i = m; i >= zeros; i--)
            {
                for (int j = n; j >= ones; j--)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
                }
            }
        }

        return dp[m, n];
    }
}