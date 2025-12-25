namespace LeetCode.MaximizeHappinessofSelectedChildren;

public class Solution
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness, (a, b) => b.CompareTo(a));
        long result = 0;
        result = happiness[0];
        for (int i = 1; i < k; i++)
        {
            result += LimitMin(happiness[i] - i, 0);
        }
        return result;
    }
    public static T LimitMin<T>(T value, T min) where T : IComparable<T>
    {
        return value.CompareTo(min) < 0 ? min : value;
    }
}
