namespace LeetCode.MinimumDifferenceBetweenHighestandLowestofKScores;


public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        Array.Sort(nums);
        int minDifference = int.MaxValue;

        for (int i = 0; i <= nums.Length - k; i++)
        {
            int currentDifference = nums[i + k - 1] - nums[i];
            minDifference = Math.Min(minDifference, currentDifference);
        }

        return minDifference;
    }
}