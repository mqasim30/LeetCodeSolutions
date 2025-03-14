namespace LeetCode.MaximumCandiesAllocatedtoKChildren;

public class Solution
{
    public int MaximumCandies(int[] candies, long k)
    {
        if (candies.Sum(c => (long)c) < k) return 0;

        int left = 1, right = candies.Max();
        int result = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (CanDistribute(candies, k, mid))
            {
                result = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
    private bool CanDistribute(int[] candies, long k, int mid)
    {
        long count = 0;
        foreach (int candy in candies)
        {
            count += candy / mid;
            if (count >= k) return true;
        }
        return count >= k;
    }
}