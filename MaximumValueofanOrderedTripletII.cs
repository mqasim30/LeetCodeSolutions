namespace LeetCode.MaximumValueofanOrderedTripletII;

public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        long max = 0;
        long min = 0;
        long result = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            result = Math.Max(result, min * nums[i]);
            min = Math.Max(min, max - nums[i]);
            max = Math.Max(max, nums[i]);
        }
        return result;
    }
}