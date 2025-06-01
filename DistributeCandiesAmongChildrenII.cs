namespace LeetCode.DistributeCandiesAmongChildrenII;

public class Solution
{
    public long DistributeCandies(int n, int limit)
    {
        long ans = 0;
        for (int i = 0; i <= Math.Min(limit, n); i++)
        {
            if (n - i > 2 * limit)
            {
                continue;
            }
            ans += Math.Min(n - i, limit) - Math.Max(0, n - i - limit) + 1;
        }
        return ans;
    }
}