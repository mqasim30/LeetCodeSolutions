namespace LeetCode.MaximumNumberofPointswithCost;

public class Solution
{
    public long MaxPoints(int[][] points)
    {
        int rows = points.Length;
        int cols = points[0].Length;
        long[] dp = new long[cols];

        // Initialize the dp array with the first row's points
        for (int i = 0; i < cols; i++)
        {
            dp[i] = points[0][i];
        }

        for (int r = 1; r < rows; r++)
        {
            long[] leftMax = new long[cols];
            long[] rightMax = new long[cols];
            long[] newDp = new long[cols];

            // Calculate leftMax for the current row
            leftMax[0] = dp[0];
            for (int i = 1; i < cols; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], dp[i] + i);
            }

            // Calculate rightMax for the current row
            rightMax[cols - 1] = dp[cols - 1] - (cols - 1);
            for (int i = cols - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], dp[i] - i);
            }

            // Calculate new dp values for the current row
            for (int i = 0; i < cols; i++)
            {
                newDp[i] = Math.Max(leftMax[i] - i, rightMax[i] + i) + points[r][i];
            }

            dp = newDp; // Update dp for the next iteration
        }

        // Find the maximum value in the last dp array
        long result = long.MinValue;
        foreach (long value in dp)
        {
            result = Math.Max(result, value);
        }

        return result;
    }
}
