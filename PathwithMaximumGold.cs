namespace LeetCode.PathwithMaximumGold
{
    public class Solution
    {
        private int DFS(int[][] grid, int row, int column)
        {
            if (row < 0 || row >= grid.Length || column < 0 || column >= grid[row].Length || grid[row][column] == 0)
            {
                return 0;
            }

            int current = grid[row][column];
            grid[row][column] = 0;

            int count = current + Math.Max(DFS(grid, row - 1, column), Math.Max(DFS(grid, row + 1, column), Math.Max(DFS(grid, row, column - 1), DFS(grid, row, column + 1))));

            grid[row][column] = current;

            return count;
        }
        public int GetMaximumGold(int[][] grid)
        {
            int res = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] != 0)
                        res = Math.Max(res, DFS(grid, row, col));
                }
            }
            return res;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[][] grid = [[1,0,7],[2,0,6],[3,4,5],[0,3,0],[9,0,20]];
    //         Console.WriteLine(solution.GetMaximumGold(grid));
    //     }
    // }
}