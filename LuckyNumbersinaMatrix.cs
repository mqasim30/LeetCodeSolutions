namespace LeetCode.LuckyNumbersinaMatrix;

public class Solution
{
    public int FindMax(int[][] matrix, int col)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.Length; i++)
        {
            max = Math.Max(matrix[i][col], max);
        }
        return max;
    }

    public IList<int> LuckyNumbers(int[][] matrix)
    {
        IList<int> answers = new List<int>();
        List<(int minValue, int colIndex)> rowMinValues = new List<(int, int)>();

        for (int i = 0; i < matrix.Length; i++)
        {
            int minNumber = matrix[i].Min();
            int minIndex = Array.IndexOf(matrix[i], minNumber);
            rowMinValues.Add((minNumber, minIndex));
        }

        foreach (var (minNumber, colIndex) in rowMinValues)
        {
            if (FindMax(matrix, colIndex) == minNumber)
            {
                answers.Add(minNumber);
            }
        }

        return answers;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] matrix = [[1, 10, 4, 2], [9, 3, 8, 7], [15, 16, 17, 12]];
        IList<int> answers = solution.LuckyNumbers(matrix);
        foreach (var item in answers)
        {
            Console.WriteLine("Value = " + item);
        }
    }
}