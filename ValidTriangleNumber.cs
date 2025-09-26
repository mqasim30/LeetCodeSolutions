namespace LeetCode.ValidTriangleNumber;

public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        var count = 0;

        for (var i = nums.Length - 1; i >= 2; i--)
        {
            var left = 0;
            var right = i - 1;

            while (left < right)
            {
                if (nums[left] + nums[right] > nums[i])
                {
                    count += right - left;
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return count;
    }
}