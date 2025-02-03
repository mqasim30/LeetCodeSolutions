namespace LeetCode.LongestStrictlyIncreasingorStrictlyDecreasingSubarray;

public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int increasingCount = 1;
        int decreasingCount = 1;
        int increasingCountResult = 1;
        int decreasingCountResult = 1;
        int prev = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > prev)
            {
                increasingCount++;
                increasingCountResult = Math.Max(increasingCountResult, increasingCount);
            }
            else
            {
                increasingCountResult = Math.Max(increasingCountResult, increasingCount);
                increasingCount = 1;
            }
            prev = nums[i];
        }

        prev = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < prev)
            {
                decreasingCount++;
                decreasingCountResult = Math.Max(decreasingCountResult, decreasingCount);
            }
            else
            {
                decreasingCountResult = Math.Max(decreasingCountResult, decreasingCount);
                decreasingCount = 1;
            }
            prev = nums[i];
        }

        return Math.Max(increasingCountResult, decreasingCountResult);
    }
}
