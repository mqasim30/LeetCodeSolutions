namespace LeetCode.MaximumNumberofIntegerstoChooseFromaRangeI;

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private bool BinarySearch(List<int> arr, int target)
    {
        int n = arr.Count;
        int start = 0, end = n - 1;
        int mid = start + (end - start) / 2;

        while (start <= end)
        {
            if (arr[mid] == target)
            {
                return true;
            }
            else if (arr[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
            mid = start + (end - start) / 2;
        }
        return false;
    }

    public int MaxCount(IList<int> banned, int n, int maxSum)
    {
        int cnt = 0;
        long sum = 0;
        List<int> sortedBanned = banned.OrderBy(x => x).ToList();

        for (int i = 1; i <= n; i++)
        {
            if (!BinarySearch(sortedBanned, i))
            {
                sum += i;
                if (sum <= maxSum)
                {
                    cnt++;
                }
                else
                {
                    return cnt;
                }
            }
        }
        return cnt;
    }
}
