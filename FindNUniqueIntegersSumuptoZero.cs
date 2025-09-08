namespace LeetCode.FindNUniqueIntegersSumuptoZero;

public class Solution
{
    public int[] SumZero(int n)
    {
        var result = new List<int>(n);
        if (n % 2 == 1) result.Add(0);

        var half = n / 2;
        for (int i = 0; i < half; i++)
        {
            var value = i + 1;
            result.Add(value);
            result.Add(-value);
        }

        return result.ToArray();
    }
}