namespace LeetCode.MaximumCountofPositiveIntegerandNegativeInteger;

public class Solution
{
    private int SearchTarget(int[] nums, int Target)
    {
        int left = 0, right = nums.Length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < Target)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }

    public int MaximumCount(int[] nums) =>
         Math.Max(SearchTarget(nums, 0), nums.Length - SearchTarget(nums, 1));
}