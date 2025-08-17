namespace LeetCode.New21Game;

public class Solution
{
    public double New21Game(int n, int k, int maxPts)
    {
        var dp = new double[n + maxPts + 1];
        for (int i = k; i <= n; i++)
            dp[i] = 1.0;

        double S = Math.Min(maxPts, n - k + 1);
        for (int j = k - 1; j >= 0; j--)
        {
            dp[j] = S / maxPts;
            S += dp[j] - dp[j + maxPts];
        }

        return dp[0];
    }
}