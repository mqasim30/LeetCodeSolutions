namespace LeetCode.MaximumAscendingSubarraySum;

public class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int sum = nums[i];
            int j = i + 1;
            while (j < nums.Length && nums[j] > nums[j - 1])
            {
                sum += nums[j];
                j++;
            }
            result = Math.Max(result, sum);
        }
        return result;
    }
}

public class MaximumAscendingSubarraySum
{
    public static void Main()
    {
        int[] nums = { 10, 20, 30, 5, 10, 50 };
        Solution solution = new();
        Console.WriteLine(solution.MaxAscendingSum(nums) == 65);
    }
}