namespace LeetCode.MinimizetheMaximumDifferenceofPairs;

public class Solution
{
    public int MinimizeMax(int[] nums, int p)
    {
        Array.Sort(nums);

        int left = 0, right = nums[nums.Length - 1] - nums[0];

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (CanFormPairs(nums, mid, p))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool CanFormPairs(int[] nums, int mid, int p)
    {
        int count = 0;
        for (int i = 0; i < nums.Length - 1 && count < p;)
        {
            if (nums[i + 1] - nums[i] <= mid)
            {
                count++;
                i += 2;
            }
            else
            {
                i++;
            }
        }
        return count >= p;
    }
}