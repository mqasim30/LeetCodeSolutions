namespace LeetCode.StrangePrinter;

public class Solution
{
    public int StrangePrinter(string s)
    {
        int n = s.Length;
        char[] sChar = s.ToCharArray();
        int[,] dp = new int[n, n];

        // Initialize dp array with -1 (indicating uncalculated states)
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = -1;
            }
        }

        return CalculateMinTurns(0, n - 1, sChar, dp);
    }

    private int CalculateMinTurns(int start, int end, char[] sChar, int[,] dp)
    {
        if (start > end)
        {
            return 0;
        }

        if (dp[start, end] != -1)
        {
            return dp[start, end];
        }

        // Assume that the character at start is not repeated further in the string
        int result = 1 + CalculateMinTurns(start + 1, end, sChar, dp);

        for (int k = start + 1; k <= end; k++)
        {
            if (sChar[k] == sChar[start])
            {
                // Optimize by considering the repeated character and splitting the problem
                int possibleBetterResult = CalculateMinTurns(start, k - 1, sChar, dp) + CalculateMinTurns(k + 1, end, sChar, dp);
                result = Math.Min(result, possibleBetterResult);
            }
        }

        dp[start, end] = result;
        return result;
    }
}
