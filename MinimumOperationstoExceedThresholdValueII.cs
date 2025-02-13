namespace LeetCode.MinimumOperationstoExceedThresholdValueII;

public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        PriorityQueue<long, long> minHeap = new PriorityQueue<long, long>();
        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
        }

        int numOperations = 0;
        while (minHeap.Peek() < k)
        {
            long x = minHeap.Dequeue();
            long y = minHeap.Dequeue();
            long newElement = Math.Min(x, y) * 2 + Math.Max(x, y);
            minHeap.Enqueue(newElement, newElement);
            numOperations++;
        }
        return numOperations;
    }
}