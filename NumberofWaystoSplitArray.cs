namespace LeetCode.NumberofWaystoSplitArray;

public class Solution
{
    public int WaysToSplitArray(int[] nums)
    {
        int n = nums.Length;

        long totalSum = 0;
        foreach (int num in nums)
        {
            totalSum += num;
        }

        long leftSum = 0;
        int validSplits = 0;
        for (int i = 0; i < n - 1; i++)
        {
            leftSum += nums[i];
            long rightSum = totalSum - leftSum;

            if (leftSum >= rightSum)
            {
                validSplits++;
            }
        }

        return validSplits;
    }
}