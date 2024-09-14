namespace LeetCode.LongestSubarrayWithMaximumBitwiseAND;
public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int max = 0;
        foreach (int num in nums)
        {
            max = Math.Max(max, num);
        }
        int ans = 0;
        int temp = 0;
        foreach (int num in nums)
        {
            if (num == max)
            {
                temp++;
            }
            else
            {
                temp = 0;
            }

            ans = Math.Max(ans, temp);
        }
        return ans;
    }
}