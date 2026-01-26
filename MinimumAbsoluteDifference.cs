namespace LeetCode.MinimumAbsoluteDifference;


public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);

        var minDiff = int.MaxValue;
        for (int i = 0; i < arr.Length - 1; i++)
            minDiff = Math.Min(minDiff, Math.Abs(arr[i + 1] - arr[i]));

        var result = new List<IList<int>>();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (Math.Abs(arr[i + 1] - arr[i]) == minDiff)
                result.Add(new List<int> { arr[i], arr[i + 1] });
        }

        return result;
    }
}