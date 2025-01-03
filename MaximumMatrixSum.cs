namespace LeetCode.MaximumMatrixSum;
class Solution
{
    public long MaxMatrixSum(int[][] matrix)
    {
        int min = int.MaxValue;
        long sum = 0;
        int negCount = 0;
        for (int i = 0; i < matrix.Length; i++)
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] < 0)
                    negCount++;
                int ab = Math.Abs(matrix[i][j]);
                min = Math.Min(min, ab);
                sum += ab;
            }
        if (negCount % 2 == 0)
            return sum;
        return sum - 2 * min;
    }
}