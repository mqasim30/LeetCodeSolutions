namespace LeetCode.FindtheMaximumLengthofValidSubsequenceII;

public class Solution
{
    public int MaximumLength(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<int, int>[] dp = new Dictionary<int, int>[n];
        int maxLength = 1;

        for (int i = 0; i < n; i++)
        {
            dp[i] = new Dictionary<int, int>();
            for (int j = 0; j < i; j++)
            {
                int mod = (nums[i] + nums[j]) % k;
                int prevLength = dp[j].ContainsKey(mod) ? dp[j][mod] : 1;
                int currLength = prevLength + 1;

                if (!dp[i].ContainsKey(mod) || currLength > dp[i][mod])
                {
                    dp[i][mod] = currLength;
                }

                maxLength = Math.Max(maxLength, dp[i][mod]);
            }
        }

        return maxLength;
    }
}