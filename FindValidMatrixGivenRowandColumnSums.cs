namespace LeetCode.FindValidMatrixGivenRowandColumnSums;

public class Solution
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        int rows = rowSum.Length;
        int cols = colSum.Length;
        int curRow = 0, curCol = 0;
        int[][] res = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            res[i] = new int[cols];
        }

        while (curRow < rows || curCol < cols)
        {
            if (curRow >= rows)
            {
                res[rows - 1][curCol] = colSum[curCol];
                curCol++;
                continue;
            }
            else if (curCol >= cols)
            {
                res[curRow][cols - 1] = rowSum[curRow];
                curRow++;
                continue;
            }

            int valueToPut = Math.Min(rowSum[curRow], colSum[curCol]);
            rowSum[curRow] -= valueToPut;
            colSum[curCol] -= valueToPut;
            res[curRow][curCol] = valueToPut;

            if (rowSum[curRow] == 0)
            {
                curRow++;
            }
            if (colSum[curCol] == 0)
            {
                curCol++;
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
//         int[] rowSum = [3, 8], colSum = [4, 7];
//         solution.RestoreMatrix(rowSum, colSum);
//     }
// }