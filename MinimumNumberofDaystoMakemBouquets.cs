namespace LeetCode.MinimumNumberofDaystoMakemBouquets;

public class Solution
{
    public int MinDays(int[] bloomDay, int m, int k)
    {
        if ((long)m * k > bloomDay.Length)
        {
            return -1;
        }

        int low = 1, high = int.MaxValue;
        while (low < high)
        {
            int mid = low + (high - low) / 2;

            if (CanMakeBouquets(bloomDay, m, k, mid))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private bool CanMakeBouquets(int[] bloomDay, int m, int k, int day)
    {
        int total = 0;

        for (int i = 0; i < bloomDay.Length; i++)
        {
            int count = 0;
            while (i < bloomDay.Length && count < k && bloomDay[i] <= day)
            {
                count++;
                i++;
            }

            if (count == k)
            {
                total++;
                i--;
            }

            if (total >= m)
            {
                return true;
            }
        }

        return false;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] bloomDay = [7, 7, 7, 7, 12, 7, 7];
        int m = 2, k = 3;
        Console.WriteLine(solution.MinDays(bloomDay, m, k));
    }
}
