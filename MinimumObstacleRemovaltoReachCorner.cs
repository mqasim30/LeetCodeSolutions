namespace LeetCode.MinimumObstacleRemovaltoReachCorner;

public class Solution
{
    public int MinimumObstacles(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[][] directions = new int[][] {
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}
        };
        var deque = new LinkedList<int[]>();
        deque.AddFirst(new int[] { 0, 0, 0 });
        int[,] visited = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                visited[i, j] = int.MaxValue;
            }
        }
        visited[0, 0] = 0;

        while (deque.Count > 0)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var current = deque.First.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            deque.RemoveFirst();
            int x = current[0], y = current[1], obstaclesRemoved = current[2];

            if (x == m - 1 && y == n - 1)
            {
                return obstaclesRemoved;
            }
            foreach (var dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];
                if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                {
                    int newObstaclesRemoved = obstaclesRemoved + grid[newX][newY];

                    if (newObstaclesRemoved < visited[newX, newY])
                    {
                        visited[newX, newY] = newObstaclesRemoved;

                        if (grid[newX][newY] == 0)
                        {
                            deque.AddFirst(new int[] { newX, newY, newObstaclesRemoved });
                        }
                        else
                        {
                            deque.AddLast(new int[] { newX, newY, newObstaclesRemoved });
                        }
                    }
                }
            }
        }

        return -1;
    }
}