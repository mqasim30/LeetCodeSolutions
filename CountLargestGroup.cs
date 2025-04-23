namespace LeetCode.CountLargestGroup;


public class Solution
{
    public int CountLargestGroup(int n)
    {
        var groups = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++)
        {
            int sum = 0;
            int num = i;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            if (!groups.ContainsKey(sum))
                groups[sum] = 0;
            groups[sum]++;
        }

        var maxSize = groups.Max(p => p.Value);
        int result = 0;
        foreach (var g in groups)
        {
            if (g.Value == maxSize)
                result++;
        }

        return result;
    }
}