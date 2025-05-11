namespace LeetCode.MinimumEqualSumofTwoArraysAfterReplacingZeros;
public class Solution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        long sum1 = SumNums(nums1);
        long sum2 = SumNums(nums2);
        long zero1 = zeroCount(nums1);
        long zero2 = zeroCount(nums2);

        if (sum1 + zero1 > sum2 + zero2)
        {
            if (zero2 == 0)
                return -1;

            return sum1 + zero1;
        }
        else if (sum1 + zero1 < sum2 + zero2)
        {
            if (zero1 == 0)
                return -1;

            return sum2 + zero2;
        }
        else
            return sum1 + zero1;
    }

    public static int zeroCount(int[] nums)
    {
        int count = 0;
        foreach (var item in nums)
            if (item == 0) count++;

        return count;
    }
    public static long SumNums(int[] nums)
    {
        long sum = 0;
        foreach (var item in nums)
            sum += item;

        return sum;
    }
}