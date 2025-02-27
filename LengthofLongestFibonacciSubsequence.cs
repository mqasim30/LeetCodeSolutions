namespace LeetCode.LengthofLongestFibonacciSubsequence;

public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        int n = arr.Length;
        var set = new HashSet<int>(arr);
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int a = arr[i], b = arr[j], l = 2;
                while (set.Contains(a + b))
                {
                    b = a + b;
                    a = b - a;
                    l++;
                }
                max = Math.Max(max, l);
            }
        }
        return max > 2 ? max : 0;
    }
}