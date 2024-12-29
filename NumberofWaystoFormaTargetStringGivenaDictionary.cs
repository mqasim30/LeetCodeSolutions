namespace LeetCode.NumberofWaystoFormaTargetStringGivenaDictionary;

public class Solution
{
    private const int MOD = 1_000_000_007;
    public int NumWays(string[] words, string target)
    {
        int m = target.Length;
        int n = words[0].Length;

        // Step 1: Precompute character frequencies at each column
        int[,] freq = new int[26, n];
        foreach (var word in words)
        {
            for (int j = 0; j < n; j++)
            {
                freq[word[j] - 'a', j]++;
            }
        }

        // Step 2: DP array to store the number of ways
        int[] dp = new int[m + 1];
        dp[0] = 1; // Base case: 1 way to form an empty target

        // Step 3: Iterate over the columns of `words`
        for (int j = 0; j < n; j++)
        {
            // Update dp array from back to front
            for (int i = m - 1; i >= 0; i--)
            {
                char targetChar = target[i];
                if (freq[targetChar - 'a', j] > 0)
                {
                    dp[i + 1] = (dp[i + 1] + (int)((long)dp[i] * freq[targetChar - 'a', j] % MOD)) % MOD;
                }
            }
        }

        return dp[m];
    }
}