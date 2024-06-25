namespace LeetCode.MaximumAverageSubarrayI;

public class Solution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        double sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        double maxSum = sum;

        for (int i = k; i < nums.Length; i++)
        {
            sum = sum - nums[i - k] + nums[i];
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum / k;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [1, 12, -5, -6, 50, 3];
//         int k = 4;
//         Console.WriteLine(solution.FindMaxAverage(nums, k));
//     }
// }
