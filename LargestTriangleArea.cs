namespace LeetCode.LargestTriangleArea;

public class Solution
{
    public double LargestTriangleArea(int[][] points)
    {
        double maxArea = 0;

        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                for (int k = j + 1; k < points.Length; k++)
                {
                    double area = Math.Abs(
                        points[i][0] * (points[j][1] - points[k][1]) +
                        points[j][0] * (points[k][1] - points[i][1]) +
                        points[k][0] * (points[i][1] - points[j][1])
                    ) / 2.0;

                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }
}
