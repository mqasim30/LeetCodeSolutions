namespace LeetCode.KthSmallestProductofTwoSortedArrays;

public class Solution
{
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
    {
        long left = -10000000000L; // Smallest possible product
        long right = 10000000000L; // Largest possible product

        while (left < right)
        {
            long mid = left + (right - left) / 2;
            if (CountLessOrEqual(nums1, nums2, mid) >= k)
            {
                right = mid; // Narrow down to smaller range
            }
            else
            {
                left = mid + 1; // Narrow down to larger range
            }
        }

        return left;
    }

    private long CountLessOrEqual(int[] nums1, int[] nums2, long target)
    {
        long count = 0;
        foreach (int num1 in nums1)
        {
            if (num1 >= 0)
            {
                count += CountPositive(nums2, num1, target);
            }
            else
            {
                count += CountNegative(nums2, num1, target);
            }
        }
        return count;
    }

    private long CountPositive(int[] nums, int num, long target)
    {
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if ((long)num * nums[mid] <= target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return low;
    }

    private long CountNegative(int[] nums, int num, long target)
    {
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if ((long)num * nums[mid] <= target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return nums.Length - low;
    }
}