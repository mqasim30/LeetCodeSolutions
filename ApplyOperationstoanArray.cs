namespace LeetCode.ApplyOperationstoanArray;

public class Solution
{
    public int[] ApplyOperations(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] *= 2;
                nums[i + 1] = 0;
            }
        }
        int write = 0;
        for (int read = 0; read < n; read++)
        {
            if (nums[read] != 0)
            {
                (nums[write], nums[read]) = (nums[read], nums[write]);
                write++;
            }
        }

        return nums;
    }
}