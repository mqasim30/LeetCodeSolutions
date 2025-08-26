namespace LeetCode.MaximumAreaofLongestDiagonalRectangle;

public class Solution
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        int maxDiaSq = 0;
        int maxArea = 0;
        foreach (var dim in dimensions)
        {
            int l = dim[0];
            int w = dim[1];
            int diaSq = l * l + w * w;
            int area = l * w;
            if (diaSq > maxDiaSq)
            {
                maxDiaSq = diaSq;
                maxArea = area;
            }
            else if (diaSq == maxDiaSq)
            {
                maxArea = Math.Max(maxArea, area);
            }
        }
        return maxArea;
    }
}