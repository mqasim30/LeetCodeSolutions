namespace LeetCode.FindtheNumberofWaystoPlacePeopleII;

public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        int ans = 0;
        Array.Sort(points, (a, b) => a[0] != b[0] ? a[0].CompareTo(b[0])
                                                  : b[1].CompareTo(a[1]));
        for (int i = 0; i < points.Length - 1; i++)
        {
            int[] pointA = points[i];
            int xMin = pointA[0] - 1;
            int xMax = int.MaxValue;
            int yMin = int.MinValue;
            int yMax = pointA[1] + 1;

            for (int j = i + 1; j < points.Length; j++)
            {
                int[] pointB = points[j];
                if (pointB[0] > xMin && pointB[0] < xMax && pointB[1] > yMin &&
                    pointB[1] < yMax)
                {
                    ans++;
                    xMin = pointB[0];
                    yMin = pointB[1];
                }
            }
        }
        return ans;
    }
}