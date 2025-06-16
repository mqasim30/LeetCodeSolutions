namespace LeetCode.MaximumDifferenceBetweenIncreasingElements;

public class Solution
{
    public int MaximumDifference(int[] nums)
    {
        int n = nums.Length;
        int ans = -1, premin = nums[0];
        for (int i = 1; i < n; ++i)
        {
            if (nums[i] > premin)
            {
                ans = Math.Max(ans, nums[i] - premin);
            }
            else
            {
                premin = nums[i];
            }
        }
        return ans;
    }
}