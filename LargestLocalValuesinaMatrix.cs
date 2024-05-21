using System.Collections.Immutable;

namespace LargestLocalValuesinaMatrix
{
    public class Solution
    {
        public int[][] LargestLocal(int[][] grid)
        {
            int[][] maxLocal = new int[grid.Length - 2][];
            int newLength = (grid.Length - 2) * (grid.Length - 2);
            int[] largestNumbers = new int[newLength];
            int max = 0;
            int rowLimit = 3;
            int colLimit = 3;

            for (int k = 0; k < newLength; k++)
            {
                max = 0;
                if (rowLimit > grid.Length || colLimit > grid.Length)
                {
                    if ((rowLimit + 1) <= grid.Length)
                    {
                        rowLimit += 1;
                        colLimit = 3;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int row = rowLimit - 3; row < rowLimit; row++)
                {
                    for (int col = colLimit - 3; col < colLimit; col++)
                    {
                        Console.WriteLine($"{row},{col} = {grid[row][col]}");
                        if (grid[row][col] > max)
                        {
                            max = grid[row][col];
                        }
                    }
                    Console.WriteLine();
                }
                largestNumbers[k] = max;
                colLimit += 1;
            }

            foreach (var item in largestNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            int index = 0;

            for (int row = 0; row < grid.Length - 2; row++)
            {

                maxLocal[row] = new int[grid.Length - 2];

                for (int col = 0; col < grid.Length - 2; col++)
                {
                    maxLocal[row][col] = largestNumbers[index];
                    index += 1;
                }
            }

            Console.WriteLine("Answer \n\n\n");

            for (int i = 0; i < maxLocal.Length; i++)
            {
                for (int j = 0; j < maxLocal.Length; j++)
                {
                    Console.WriteLine($"{i},{j} = {maxLocal[i][j]}");
                }
                Console.WriteLine();
            }

            return maxLocal;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[][] grid = [[1,1,1,1,1],[1,1,1,1,1],[1,1,2,1,1],[1,1,1,1,1],[1,1,1,1,1]];
    //         solution.LargestLocal(grid);
    //     }
    // }
}