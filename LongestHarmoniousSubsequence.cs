namespace LeetCode.LongestHarmoniousSubsequence;

public class Solution
{
    public int FindLHS(int[] nums)
    {
        var counts = new Dictionary<int, int>();

        var result = 0;
        foreach (var num in nums)
        {
            if (!counts.ContainsKey(num))
                counts[num] = 1;
            else
                counts[num]++;
        }

        foreach (var key in counts.Keys)
            if (counts.ContainsKey(key + 1))
                result = Math.Max(result, counts[key] + counts[key + 1]);

        return result;
    }
}