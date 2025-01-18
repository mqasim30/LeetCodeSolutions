namespace LeetCode.MinimumCosttoMakeatLeastOneValidPathinaGrid;

public class Solution
{
    public int MinCost(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[,] cost = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                cost[i, j] = int.MaxValue;

        cost[0, 0] = 0;
        var pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), 0);
        int[][] directions = new int[][] {
            new int[] {0, 1}, // Right
            new int[] {0, -1}, // Left
            new int[] {1, 0}, // Down
            new int[] {-1, 0} // Up
        };

        while (pq.Count > 0)
        {
            var (x, y) = pq.Dequeue();

            // If we reached the bottom-right cell
            if (x == m - 1 && y == n - 1)
                return cost[x, y];

            // Get the direction based on the grid's sign
            int dir = grid[x][y] - 1; // Convert to 0-based index
            int newX = x + directions[dir][0], newY = y + directions[dir][1];

            // Move to the next cell based on the sign
            if (IsInBounds(newX, newY, m, n) && cost[newX, newY] > cost[x, y])
            {
                cost[newX, newY] = cost[x, y];
                pq.Enqueue((newX, newY), cost[newX, newY]);
            }

            // Try changing the direction for each valid move
            for (int i = 0; i < 4; i++)
            {
                newX = x + directions[i][0];
                newY = y + directions[i][1];

                if (IsInBounds(newX, newY, m, n) && cost[newX, newY] > cost[x, y] + 1)
                {
                    cost[newX, newY] = cost[x, y] + 1;
                    pq.Enqueue((newX, newY), cost[newX, newY]);
                }
            }
        }

        return -1; // This line should never be reached
    }

    private bool IsInBounds(int x, int y, int m, int n)
    {
        return x >= 0 && x < m && y >= 0 && y < n;
    }
}