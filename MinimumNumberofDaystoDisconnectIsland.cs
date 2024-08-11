namespace LeetCode.MinimumNumberofDaystoDisconnectIsland;

public class Solution
{
    public int MinDays(int[][] grid)
    {
        // If the grid is already disconnected, return 0 days
        if (CountIslands(grid) != 1)
        {
            return 0;
        }

        int rows = grid.Length;
        int cols = grid[0].Length;

        // Try removing each land cell to see if it disconnects the island
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 0; // Temporarily remove the land
                    if (CountIslands(grid) != 1)
                    {
                        return 1; // If the grid is disconnected after removal, return 1 day
                    }
                    grid[i][j] = 1; // Restore the land
                }
            }
        }

        // If no single removal can disconnect the island, it takes 2 days
        return 2;
    }

    // Counts the number of islands in the grid
    private int CountIslands(int[][] grid)
    {
        bool[,] seen = new bool[grid.Length, grid[0].Length];
        int islands = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1 && !seen[i, j])
                {
                    islands++;
                    Dfs(grid, i, j, seen);
                }
            }
        }

        return islands;
    }

    private void Dfs(int[][] grid, int r, int c, bool[,] seen)
    {
        seen[r, c] = true;
        int[][] directions = { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };

        foreach (var dir in directions)
        {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr >= 0 && nr < grid.Length && nc >= 0 && nc < grid[0].Length && grid[nr][nc] == 1 && !seen[nr, nc])
            {
                Dfs(grid, nr, nc, seen);
            }
        }
    }
}
