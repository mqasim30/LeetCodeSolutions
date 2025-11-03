namespace LeetCode.MinimumTimetoMakeRopeColorful;

public class Solution
{
    public int MinCost(string colors, int[] neededTime)
    {
        int ans = neededTime[0];
        int max = neededTime[0];
        for (int i = 1; i < colors.Length; i++)
        {
            ans += neededTime[i];
            if (colors[i] != colors[i - 1])
            {
                ans -= max;
                max = neededTime[i];
            }
            else if (neededTime[i] > max) max = neededTime[i];
        }
        ans -= max;
        return ans;
    }
}