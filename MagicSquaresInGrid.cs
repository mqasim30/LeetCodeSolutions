namespace LeetCode.MagicSquaresInGrid;
public class Solution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        if (rowCount < 3 || colCount < 3) return 0;

        int magicSquareCount = 0;

        for (int i = 1; i < rowCount - 1; i++)
        {
            for (int j = 1; j < colCount - 1; j++)
            {
                if (grid[i][j] == 5 && IsMagicSquare(grid, i, j))
                {
                    magicSquareCount++;
                }
            }
        }

        return magicSquareCount;
    }

    private bool IsMagicSquare(int[][] grid, int centerX, int centerY)
    {
        bool[] seenNumbers = new bool[10];
        int[] rowSums = new int[3];
        int[] colSums = new int[3];

        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int colOffset = -1; colOffset <= 1; colOffset++)
            {
                int currentNumber = grid[centerX + rowOffset][centerY + colOffset];

                if (currentNumber < 1 || currentNumber > 9 || seenNumbers[currentNumber])
                {
                    return false;
                }

                seenNumbers[currentNumber] = true;
                rowSums[rowOffset + 1] += currentNumber;
                colSums[colOffset + 1] += currentNumber;
            }
        }

        // Check if all numbers from 1 to 9 are present and unique
        for (int i = 1; i <= 9; i++)
        {
            if (!seenNumbers[i]) return false;
        }

        // Check if all rows, columns, and diagonals sum to 15
        if (rowSums[0] != 15 || rowSums[1] != 15 || rowSums[2] != 15) return false;
        if (colSums[0] != 15 || colSums[1] != 15 || colSums[2] != 15) return false;

        // Check diagonals
        if (grid[centerX - 1][centerY - 1] + grid[centerX + 1][centerY + 1] != 10) return false;
        if (grid[centerX + 1][centerY - 1] + grid[centerX - 1][centerY + 1] != 10) return false;

        return true;
    }
}
