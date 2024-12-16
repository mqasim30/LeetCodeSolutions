namespace LeetCode.FinalArrayStateAfterKMultiplicationOperationsI;


public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        var minHeap = new PriorityQueue<int, (int, int)>(Comparer<(int, int)>.Create((a, b) =>
        {
            if (a.Item1 == b.Item1)
                return a.Item2.CompareTo(b.Item2);
            return a.Item1.CompareTo(b.Item1);
        }));

        for (int i = 0; i < nums.Length; i++)
        {
            minHeap.Enqueue(i, (nums[i], i));
        }

        while (k > 0)
        {
            var top = minHeap.Dequeue();
            nums[top] = nums[top] * multiplier;
            minHeap.Enqueue(top, (nums[top], top));
            k--;
        }

        return nums;
    }
}