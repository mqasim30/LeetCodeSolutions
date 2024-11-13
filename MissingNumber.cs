namespace LeetCode.MissingNumber;

public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int N = nums.Length;
        int expectedSum = N * (N + 1) / 2;
        int actualSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            actualSum += nums[i];
        }
        return expectedSum - actualSum;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new();
        int[] nums = [1, 2, 4, 6, 3, 7, 8];
        Console.WriteLine("This is the missing number: " + solution.MissingNumber(nums));
    }
}
//1+2+3+4+5+6+7+8 = 36
//1+2+4+6+3+7+8 = 31