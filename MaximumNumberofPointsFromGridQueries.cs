namespace LeetCode.MaximumNumberofPointsFromGridQueries;

public class Solution
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int m = grid.Length, n = grid[0].Length;
        int[] result = new int[queries.Length];
        int[][] directions = { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int[][] indexedQueries = new int[queries.Length][];
        for (int i = 0; i < queries.Length; i++)
        {
            indexedQueries[i] = new int[] { queries[i], i };
        }
        Array.Sort(indexedQueries, (a, b) => a[0].CompareTo(b[0]));
        PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
        bool[,] visited = new bool[m, n];
        pq.Enqueue(new int[] { grid[0][0], 0, 0 }, grid[0][0]);
        visited[0, 0] = true;

        int points = 0;
        int lastProcessedValue = 0;

        foreach (var query in indexedQueries)
        {
            int qValue = query[0], idx = query[1];
            while (pq.Count > 0 && pq.Peek()[0] < qValue)
            {
                int[] cell = pq.Dequeue();
                int cellValue = cell[0], r = cell[1], c = cell[2];
                points++;
                lastProcessedValue = cellValue;
                foreach (var dir in directions)
                {
                    int newRow = r + dir[0], newCol = c + dir[1];
                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol])
                    {
                        pq.Enqueue(new int[] { grid[newRow][newCol], newRow, newCol }, grid[newRow][newCol]);
                        visited[newRow, newCol] = true;
                    }
                }
            }
            result[idx] = points;
        }

        return result;
    }
}