namespace LeetCode.MaximumScoreAfterSplittingaString;

public class Solution
{
    public int MaxScore(string s)
    {
        int maxScore = 0;
        int zeros = 0;
        int ones = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                ones++;
            }
        }

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '0')
            {
                zeros++;
            }
            else
            {
                ones--;
            }

            maxScore = Math.Max(maxScore, zeros + ones);
        }

        return maxScore;
    }
}