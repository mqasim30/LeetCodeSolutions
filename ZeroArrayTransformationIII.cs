namespace LeetCode.ZeroArrayTransformationIII;

public class Solution
{
    public int MaxRemoval(int[] nums, int[][] queries)
    {
        Array.Sort(queries, (a, b) => a[0] - b[0]);
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => -1 * a.CompareTo(b)));
        int[] sweep = new int[nums.Length + 1];
        int index = 0, cs = 0, taken = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            cs += sweep[i];
            while (index < queries.Length && queries[index][0] <= i)
            {
                pq.Enqueue(queries[index][1], queries[index][1]);
                index++;
            }
            while (pq.Count > 0 && cs < nums[i])
            {
                int top = pq.Peek();
                pq.Dequeue();
                if (top < i)
                {
                    continue;
                }
                cs++;
                taken++;
                sweep[top + 1] += -1;
            }
            if (cs < nums[i])
                return -1;
        }
        return queries.Length - taken;
    }
}