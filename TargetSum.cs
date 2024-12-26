namespace LeetCode.TargetSum;

public class Solution
{
    public int FindTargetSumWays(int[] nums, int target, int index = 0) =>
        (index < nums.Length)
        ? FindTargetSumWays(nums, target - nums[index], index + 1) +
            FindTargetSumWays(nums, target + nums[index], index + 1)
        : target == 0 ? 1 : 0;
}