namespace LeetCode.MinimumOperationstoMakeaUniValueGrid;

public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        var l = new List<int>();
        foreach (int[] i in grid)
            l.AddRange(i);
        l = l.OrderBy(c => c).ToList();
        int median = l[l.Count / 2];
        int steps = 0;

        foreach (int val in l)
        {
            int diff = Math.Abs(val - median);
            if (diff % x != 0)
                return -1;
            steps += diff / x;
        }
        return steps;
    }
}