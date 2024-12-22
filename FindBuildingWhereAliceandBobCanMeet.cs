namespace LeetCode.FindBuildingWhereAliceandBobCanMeet;
using System;
using System.Collections.Generic;

public class Solution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        int n = heights.Length;
        int[,] st = new int[n, 20];
        int[] Log = new int[n + 1];

        // Compute logarithms
        Log[0] = -1;
        for (int i = 1; i <= n; i++)
        {
            Log[i] = Log[i / 2] + 1;
        }

        // Build the sparse table
        for (int i = 0; i < n; i++)
        {
            st[i, 0] = heights[i];
        }
        for (int i = 1; i < 20; i++)
        {
            for (int j = 0; j + (1 << i) <= n; j++)
            {
                st[j, i] = Math.Max(st[j, i - 1], st[j + (1 << (i - 1)), i - 1]);
            }
        }

        int Ask(int l, int r)
        {
            int k = Log[r - l + 1];
            return Math.Max(st[l, k], st[r - (1 << k) + 1, k]);
        }

        List<int> res = new List<int>();

        foreach (var query in queries)
        {
            int l = query[0];
            int r = query[1];
            if (l > r)
            {
                (l, r) = (r, l);
            }

            if (l == r)
            {
                res.Add(l);
                continue;
            }

            if (heights[r] > heights[l])
            {
                res.Add(r);
                continue;
            }

            int max_height = Math.Max(heights[r], heights[l]);
            int left = r + 1, right = n;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (Ask(r + 1, mid) > max_height)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            res.Add(left != n ? left : -1);
        }

        return res.ToArray();
    }
}
