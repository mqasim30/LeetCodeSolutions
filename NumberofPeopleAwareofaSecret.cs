namespace LeetCode.NumberofPeopleAwareofaSecret;

public class Solution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {

        long[] dp = new long[forget + 1], tmp = new long[forget + 1];
        dp[1] = 1;
        int curD = 1, mod = 1000000007;
        while (curD < n)
        {
            curD++;
            Array.Clear(tmp, 0, forget + 1);
            for (int i = forget; i > 1; i--)
            {
                tmp[i] += dp[i - 1];
                if (i > delay)
                    tmp[1] += dp[i - 1];

                tmp[i] %= mod;
            }
            Array.Copy(tmp, dp, forget + 1);
        }

        long res = 0;
        for (int i = 1; i <= forget; i++)
        {
            res += dp[i];
            res %= mod;
        }

        return (int)res;
    }
}