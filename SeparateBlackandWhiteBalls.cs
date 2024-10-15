namespace LeetCode.SeparateBlackandWhiteBalls;

public class Solution
{
    public long MinimumSteps(string s)
    {
        int whitePosition = 0;
        long totalSwaps = 0;
        for (int currentPos = 0; currentPos < s.Length; currentPos++)
        {
            if (s[currentPos] == '0')
            {
                totalSwaps += currentPos - whitePosition;

                whitePosition++;
            }
        }

        return totalSwaps;
    }
}