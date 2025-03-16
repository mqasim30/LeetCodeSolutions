namespace LeetCode.MinimumTimetoRepairCars;

public class Solution
{
    private bool canAchieveThisTime(long time, int[] ranks, int cars)
    {
        long RepairedCars = 0;
        for (int i = 0; i < ranks.Length; i++)
        {
            long n = (long)Math.Sqrt(time / ranks[i]);
            RepairedCars += n;
        }
        return RepairedCars >= cars;
    }
    public long RepairCars(int[] ranks, int cars)
    {
        long l = 0, r = (long)1e14, ans = 0;
        while (l <= r)
        {
            long time = (l + r) / 2;
            if (canAchieveThisTime(time, ranks, cars))
            {
                ans = time;
                r = time - 1;
            }
            else l = time + 1;
        }
        return ans;
    }
}