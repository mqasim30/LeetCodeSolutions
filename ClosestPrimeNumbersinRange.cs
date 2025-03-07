namespace LeetCode.ClosestPrimeNumbersinRange;

public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        int[] arr = new int[] { -1, -1 };
        List<int> list = new List<int>();
        for (int i = left; i <= right; i++)
        {
            if (IsPrime(i))
            {
                list.Add(i);
            }
        }
        if (list.Count <= 1) { return arr; }
        int closestCount = int.MaxValue;
        int[] ans = new int[2];
        ans[0] = int.MaxValue; ans[1] = int.MaxValue;
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i + 1] - list[i] < closestCount)
            {
                closestCount = list[i + 1] - list[i];
                ans[0] = list[i]; ans[1] = list[i + 1];
            }
        }
        return ans;
    }
    public bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}