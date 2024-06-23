namespace LeetCode.LongestContinuousSubarrayWithAbsoluteDiffLessThanorEqualtoLimit;

using System;
using System.Collections.Generic;

public class Solution
{
    public int LongestSubarray(int[] nums, int limit)
    {
        LinkedList<int> increase = new LinkedList<int>();
        LinkedList<int> decrease = new LinkedList<int>();

        int max = 0;
        int left = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            while (increase.Count > 0 && n < increase.Last.Value)
            {
                increase.RemoveLast();
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            increase.AddLast(n);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            while (decrease.Count > 0 && n > decrease.Last.Value)
            {
                decrease.RemoveLast();
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            decrease.AddLast(n);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            while (decrease.First.Value - increase.First.Value > limit)
            {
                if (nums[left] == decrease.First.Value)
                {
                    decrease.RemoveFirst();
                }
                if (nums[left] == increase.First.Value)
                {
                    increase.RemoveFirst();
                }
                left++;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            int size = i - left + 1;
            max = Math.Max(max, size);
        }

        return max;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [8, 2, 4, 7];
        int limit = 4;
        Console.WriteLine(solution.LongestSubarray(nums, limit));
    }
}