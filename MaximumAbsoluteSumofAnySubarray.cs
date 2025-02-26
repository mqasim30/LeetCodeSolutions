namespace LeetCode.MaximumAbsoluteSumofAnySubarray;

public class Solution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        int min = 0, max = 0, sum = 0, best = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sum < min) min = sum;
            int c1 = sum - min;
            if (c1 > best) best = c1;
            if (sum > max) max = sum;
            int c2 = max - sum;
            if (c2 > best) best = c2;
        }
        return best;
    }
}