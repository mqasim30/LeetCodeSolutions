namespace LeetCode.MinimumDifferenceBetweenLargestandSmallestValueinThreeMoves;

public class Solution
{
    public int MinDifference(int[] nums)
    {
        if (nums.Length <= 4)
        {
            return 0;
        }
        Array.Sort(nums);
        int ans = nums[nums.Length - 1] - nums[0];
        for (int i = 0; i <= 3; i++)
        {
            ans = Math.Min(ans, nums[nums.Length - (3 - i) - 1] - nums[i]);
        }
        return ans;
    }
}