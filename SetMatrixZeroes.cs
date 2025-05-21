namespace LeetCode.SetMatrixZeroes;

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int rowLength = matrix.Length;
        if (rowLength == 0) return;
        int columnLength = matrix[0].Length;

        var rowZero = new bool[rowLength];
        var columnZero = new bool[columnLength];

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < columnLength; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rowZero[i] = true;
                    columnZero[j] = true;
                }
            }
        }

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < columnLength; j++)
            {
                if (rowZero[i] || columnZero[j])
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }

}