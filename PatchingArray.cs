namespace LeetCode.PatchingArray;

public class Solution
{
    public int MinPatches(int[] nums, int n)
    {
        int result = 0;
        long num = 1;
        int i = 0;

        while (num <= n)
        {
            if (i < nums.Length && nums[i] <= num)
            {
                num += nums[i];
                i++;
            }
            else
            {
                num += num;
                result++;
            }
        }

        return result;
    }
}


public class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [1, 3];
        int n = 6;
        Console.WriteLine(solution.MinPatches(nums, n));
    }
}

