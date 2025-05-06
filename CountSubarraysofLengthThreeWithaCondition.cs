namespace LeetCode.CountSubarraysofLengthThreeWithaCondition;

public class Solution
{
    public int CountSubarrays(int[] nums)
    {
        var count = 0;

        for (var i = 0; i + 2 < nums.Length; i++)
            if (nums[i + 1] == 2 * (nums[i] + nums[i + 2]))
                count++;

        return count;
    }
}