namespace LeetCode.ShortestCommonSupersequence;
using System.Text;
public class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {

        int n = str1.Length, m = str2.Length;
        var dp = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        int i1 = n, i2 = m;
        var sb = new StringBuilder();
        while (i1 > 0 && i2 > 0)
        {
            if (str1[i1 - 1] == str2[i2 - 1])
            {
                sb.Append(str1[i1 - 1]);
                i1--;
                i2--;
            }
            else if (dp[i1 - 1, i2] > dp[i1, i2 - 1])
            {
                sb.Append(str1[i1 - 1]);
                i1--;
            }
            else
            {
                sb.Append(str2[i2 - 1]);
                i2--;
            }
        }

        while (i1 > 0)
        {
            sb.Append(str1[i1 - 1]);
            i1--;
        }

        while (i2 > 0)
        {
            sb.Append(str2[i2 - 1]);
            i2--;
        }

        return new string(sb.ToString().Reverse().ToArray());

    }
}