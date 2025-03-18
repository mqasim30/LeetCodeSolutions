namespace LeetCode.LongestNiceSubarray;

public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int maxLength = 1;
        int l = 0, r = 0;
        int usedBits = 0;

        for (r = 0; r < nums.Length; ++r)
        {
            while ((usedBits & nums[r]) != 0)
            {
                usedBits ^= nums[l];
                ++l;
            }

            usedBits |= nums[r];
            maxLength = Math.Max(maxLength, r - l + 1);
        }

        return maxLength;
    }
}