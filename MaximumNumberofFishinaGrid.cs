namespace LeetCode.MaximumNumberofFishinaGrid;

public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int maxFish = 0;

        bool[,] visited = new bool[rows, cols];
        int[][] directions = new int[][] {
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}
        };
        int BFS(int startRow, int startCol)
        {
            int totalFish = 0;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startRow, startCol));
            visited[startRow, startCol] = true;

            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                totalFish += grid[r][c];
                foreach (var dir in directions)
                {
                    int newRow = r + dir[0];
                    int newCol = c + dir[1];
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols
                        && grid[newRow][newCol] > 0 && !visited[newRow, newCol])
                    {
                        visited[newRow, newCol] = true;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }

            return totalFish;
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] > 0 && !visited[i, j])
                {
                    maxFish = Math.Max(maxFish, BFS(i, j));
                }
            }
        }

        return maxFish;
    }
}