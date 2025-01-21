namespace LeetCode.GridGame;

public class Solution
{
    public long GridGame(int[][] grid)
    {
        long result = 0;
        int[] row0 = grid[0], row1 = grid[1];
        int leftIndex = 0, rightIndex = row0.Length - 1;
        long nextLeftSum = row1[leftIndex], nextRightSum = row0[rightIndex], leftSum = 0, rightSum = 0;
        for (; leftIndex < rightIndex;)
        {
            if (nextLeftSum < nextRightSum)
            {
                leftSum = nextLeftSum; nextLeftSum += row1[++leftIndex];
            }
            else
            {
                rightSum = nextRightSum; nextRightSum += row0[--rightIndex];
            }
        }
        result = Math.Max(leftSum, rightSum);
        return result;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new();
//         int[][] grid = new int[][]
//         {
//             new int[] {3,3,1},
//             new int[] {8,5,2}
//         };
//         Console.WriteLine(solution.GridGame(grid));
//     }
// }