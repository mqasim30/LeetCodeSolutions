namespace LeetCode.MaximumTotalDamageWithSpellCasting;

public class Solution
{
    public long MaximumTotalDamage(int[] p)
    {
        Dictionary<long, long> d = new Dictionary<long, long>();
        for (int i = 0; i < p.Length; i++)
        {
            if (d.ContainsKey(p[i])) d[p[i]]++;
            else d.Add(p[i], 1);
        }
        long[] a = new long[d.Count];
        int ind = 0;
        foreach (int i in d.Keys)
        {
            a[ind] = (long)i;
            ind++;
        }
        Array.Sort(a);

        long[] dp = new long[a.Length];
        dp[0] = a[0] * d[a[0]];
        long ans = dp[0];
        for (int i = 1; i < a.Length; i++)
        {
            dp[i] = a[i] * d[a[i]];
            for (int j = i - 1; j >= Math.Max(0, i - 5); j--)
            {
                if (a[j] + 2 < a[i]) dp[i] = Math.Max(dp[i], dp[j] + (a[i] * d[a[i]]));
            }
            ans = Math.Max(dp[i], ans);
        }
        return ans;
    }
}