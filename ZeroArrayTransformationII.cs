namespace LeetCode.ZeroArrayTransformationII;

public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int left = 0, right = queries.Length;

        if (!CanFormZeroArray(nums, queries, right))
        {
            return -1;
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanFormZeroArray(nums, queries, mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
    private bool CanFormZeroArray(int[] nums, int[][] queries, int k)
    {
        int n = nums.Length;
        int[] differenceArray = new int[n + 1];

        for (int i = 0; i < k; i++)
        {
            int li = queries[i][0], ri = queries[i][1], vali = queries[i][2];
            differenceArray[li] += vali;
            if (ri + 1 < n)
            {
                differenceArray[ri + 1] -= vali;
            }
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += differenceArray[i];
            if (sum < nums[i])
            {
                return false;
            }
        }

        return true;
    }
}