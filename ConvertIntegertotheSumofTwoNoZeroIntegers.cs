namespace LeetCode.ConvertIntegertotheSumofTwoNoZeroIntegers;

public class Solution
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (int i = 1; i < n; i++)
        {
            var j = n - i;
            if (!HasZero(i) && !HasZero(j))
            {
                return new[] { i, j };
            }
        }

        return Array.Empty<int>();
    }

    private bool HasZero(int n)
    {
        while (n > 0)
        {
            if (n % 10 == 0) return true;
            n /= 10;
        }

        return false;
    }
}   