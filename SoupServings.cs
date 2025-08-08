namespace LeetCode.SoupServings;

public class Solution
{
    public double SoupServings(int n)
    {
        int m = (int)Math.Ceiling(n / 25.0);
        Dictionary<int, Dictionary<int, double>> dp = new Dictionary<int, Dictionary<int, double>>();

        for (int k = 1; k <= m; k++)
        {
            double result = CalculateDP(k, k, dp);
            if (result > 1 - 1e-5)
            {
                return 1.0;
            }
        }
        return CalculateDP(m, m, dp);
    }

    private double CalculateDP(int i, int j, Dictionary<int, Dictionary<int, double>> dp)
    {
        if (i <= 0 && j <= 0)
        {
            return 0.5;
        }
        if (i <= 0)
        {
            return 1.0;
        }
        if (j <= 0)
        {
            return 0.0;
        }
        if (dp.ContainsKey(i) && dp[i].ContainsKey(j))
        {
            return dp[i][j];
        }
        double result = (CalculateDP(i - 4, j, dp) + CalculateDP(i - 3, j - 1, dp) +
                        CalculateDP(i - 2, j - 2, dp) + CalculateDP(i - 1, j - 3, dp)) / 4.0;
        if (!dp.ContainsKey(i))
        {
            dp[i] = new Dictionary<int, double>();
        }
        dp[i][j] = result;
        return result;
    }
}