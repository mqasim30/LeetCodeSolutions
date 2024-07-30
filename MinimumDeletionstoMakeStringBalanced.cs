namespace LeetCode.MinimumDeletionstoMakeStringBalanced;

public class Solution
{
    public int MinimumDeletions(string s)
    {
        int n = s.Length;
        int[] f = new int[n + 1];
        int b = 0;

        for (int i = 1; i <= n; ++i)
        {
            if (s[i - 1] == 'b')
            {
                f[i] = f[i - 1];
                ++b;
            }
            else
            {
                f[i] = Math.Min(f[i - 1] + 1, b);
            }
        }

        return f[n];
    }
}
