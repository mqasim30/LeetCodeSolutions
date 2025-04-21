namespace LeetCode.CounttheHiddenSequences;
public class Solution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        long prefixSum = 0;
        long minPrefix = 0;
        long maxPrefix = 0;

        foreach (int diff in differences)
        {
            prefixSum += diff;
            minPrefix = Math.Min(minPrefix, prefixSum);
            maxPrefix = Math.Max(maxPrefix, prefixSum);
        }

        long minStart = lower - minPrefix;
        long maxStart = upper - maxPrefix;

        return (int)Math.Max(0, maxStart - minStart + 1);
    }
}