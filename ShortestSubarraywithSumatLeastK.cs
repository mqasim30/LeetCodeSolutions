namespace LeetCode.ShortestSubarraywithSumatLeastK;

public class Solution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        int res = int.MaxValue;
        long curSum = 0;
        var q = new LinkedList<(long sum, int index)>();

        for (int r = 0; r < nums.Length; r++)
        {
            curSum += nums[r];
            if (curSum >= k)
            {
                res = Math.Min(res, r + 1);
            }

            // Find the minimum valid window ending at r
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            while (q.Count > 0 && curSum - q.First.Value.sum >= k)
            {
                var (prefix, endIdx) = q.First.Value;
                q.RemoveFirst();
                res = Math.Min(res, r - endIdx);
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // Validate the monotonic deque
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            while (q.Count > 0 && q.Last.Value.sum > curSum)
            {
                q.RemoveLast();
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            q.AddLast((curSum, r));
        }

        return res == int.MaxValue ? -1 : res;
    }
}