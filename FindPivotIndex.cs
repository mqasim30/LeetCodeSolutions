namespace LeetCode.FindPivotIndex;

public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int totalSum = 0;
        foreach (var num in nums)
        {
            totalSum += num;
        }
        int leftSum = 0;
        int rightSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            rightSum = totalSum - leftSum - nums[i];
            if (leftSum == rightSum)
            {
                return i;
            }
            else
            {
                leftSum += nums[i];
            }
        }
        return -1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [1, 7, 3, 6, 5, 6];
        Console.WriteLine("Result = " + solution.PivotIndex(nums));
    }
}