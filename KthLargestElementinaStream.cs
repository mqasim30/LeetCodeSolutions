namespace LeetCode.KthLargestElementinaStream;
public class KthLargest
{
    private readonly int k;
    private readonly PriorityQueue<int, int> minHeap;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val)
    {
        if (minHeap.Count < k)
        {
            minHeap.Enqueue(val, val);
        }
        else if (val > minHeap.Peek())
        {
            minHeap.Enqueue(val, val);
            minHeap.Dequeue();
        }

        return minHeap.Peek();
    }
}
