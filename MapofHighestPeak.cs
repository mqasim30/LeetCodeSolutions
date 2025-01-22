namespace LeetCode.MapofHighestPeak;

public class Solution
{
    public int[][] HighestPeak(int[][] isWater)
    {
        int m = isWater.Length;
        int n = isWater[0].Length;
        int[][] height = new int[m][];

        for (int i = 0; i < m; i++)
        {
            height[i] = new int[n];
            Array.Fill(height[i], -1);
        }

        int[][] directions = new int[][] {
            new int[] {-1, 0},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {0, 1}
        };

        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isWater[i][j] == 1)
                {
                    height[i][j] = 0;
                    queue.Enqueue((i, j));
                }
            }
        }

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            foreach (var dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];

                if (newX >= 0 && newX < m && newY >= 0 && newY < n && height[newX][newY] == -1)
                {
                    height[newX][newY] = height[x][y] + 1;
                    queue.Enqueue((newX, newY));
                }
            }
        }

        return height;
    }
}