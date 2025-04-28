namespace LeetCode.CountSubarraysWithScoreLessThanK;
public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        int n = nums.Length;
        long res = 0, total = 0;
        for (int i = 0, j = 0; j < n; j++)
        {
            total += nums[j];
            while (i <= j && total * (j - i + 1) >= k)
            {
                total -= nums[i];
                i++;
            }
            res += j - i + 1;
        }
        return res;
    }
}