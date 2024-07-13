namespace LeetCode.EqualRowandColumnPairs;
public class Solution
{
    public int EqualPairs(int[][] grid)
    {
        int results = 0;
        int n = grid.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                bool isEqual = true;

                for (int k = 0; k < n; k++)
                {
                    if (grid[i][k] != grid[k][j])
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (isEqual)
                {
                    results++;
                }
            }
        }

        return results;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] grid = [[3, 1, 2, 2], [1, 4, 4, 5], [2, 4, 2, 2], [2, 4, 2, 2]];
        Console.WriteLine(solution.EqualPairs(grid));
    }
}


