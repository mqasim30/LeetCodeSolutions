namespace LeetCode.BitwiseXORofAllPairings;

public class Solution
{
    public int XorAllNums(int[] nums1, int[] nums2)
    {
        int xor1 = 0, xor2 = 0;

        foreach (int num in nums1)
        {
            xor1 ^= num;
        }

        foreach (int num in nums2)
        {
            xor2 ^= num;
        }

        int result = 0;

        if (nums2.Length % 2 == 1)
        {
            result ^= xor1;
        }

        if (nums1.Length % 2 == 1)
        {
            result ^= xor2;
        }

        return result;
    }
}