namespace LeetCode.MaximalRectangle;

public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        if (matrix == null || matrix.Length == 0)
            return 0;

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[] heights = new int[cols];
        int maxArea = 0;

        for (int i = 0; i < rows; i++)
        {
            // Build histogram for current row
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == '1')
                {
                    heights[j]++;
                }
                else
                {
                    heights[j] = 0;
                }
            }

            // Compute max rectangle area in histogram
            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }

        return maxArea;
    }
    private int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int n = heights.Length;

        for (int i = 0; i <= n; i++)
        {
            int currentHeight = (i == n) ? 0 : heights[i];

            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            stack.Push(i);
        }

        return maxArea;
    }
}