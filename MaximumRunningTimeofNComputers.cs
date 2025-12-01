namespace LeetCode.MaximumRunningTimeofNComputers;

public class Solution
{
    public long MaxRunTime(int n, int[] batteries)
    {
        long total = 0;
        foreach (int b in batteries) total += b;

        long left = 0, right = total / n;

        while (left < right)
        {
            long mid = (left + right + 1) >> 1;
            long need = mid * n, have = 0;

            foreach (int b in batteries)
                have += Math.Min(b, mid);

            if (have >= need) left = mid;
            else right = mid - 1;
        }

        return left;
    }
}