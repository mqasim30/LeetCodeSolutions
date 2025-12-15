namespace LeetCode.NumberofSmoothDescentPeriodsofaStock;

public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        int n = prices.Length;
        long res = 1;
        int prev = 1;
        for (int i = 1; i < n; ++i)
        {
            if (prices[i] == prices[i - 1] - 1)
            {
                ++prev;
            }
            else
            {
                prev = 1;
            }
            res += prev;
        }
        return res;
    }
}