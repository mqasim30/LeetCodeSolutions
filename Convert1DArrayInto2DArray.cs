namespace LeetCode.Convert1DArrayInto2DArray;
public class Solution
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        int[][] result = new int[m][];

        switch (m * n == original.Length ? 1 : 0)
        {
            case 1:
                int i = 0;
                while (i < m)
                {
                    result[i] = new int[n];
                    Array.Copy(original, i * n, result[i], 0, n);
                    i++;
                }
                break;
            default:
                return new int[0][];
        }

        return result;
    }
}