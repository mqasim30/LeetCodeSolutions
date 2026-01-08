namespace LeetCode.MaxDotProductofTwoSubsequences;

public class Solution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int m = nums2.Length;

        // dp[i][j] = maximum dot product using
        // non-empty subsequences from nums1[0..i-1] and nums2[0..j-1]
        int[,] dp = new int[n + 1, m + 1];

        int NEG_INF = -1_000_000_000;

        // Initialize DP table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                dp[i, j] = NEG_INF;
            }
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int product = nums1[i - 1] * nums2[j - 1];

                // Option 1: start a new subsequence
                int takeBoth = product;

                // Option 2: extend an existing subsequence
                int extend = dp[i - 1, j - 1] != NEG_INF
                             ? dp[i - 1, j - 1] + product
                             : NEG_INF;

                // Option 3: skip one element
                int skip = Math.Max(dp[i - 1, j], dp[i, j - 1]);

                dp[i, j] = Math.Max(Math.Max(takeBoth, extend), skip);
            }
        }

        return dp[n, m];
    }
}