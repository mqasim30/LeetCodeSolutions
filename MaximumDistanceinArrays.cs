namespace LeetCode.MaximumDistanceinArrays;

public class Solution
{
    public int MaxDistance(IList<IList<int>> arrays)
    {
        int smallest = arrays[0][0];
        int largest = arrays[0][arrays[0].Count - 1];
        int maxDistance = 0;

        for (int i = 1; i < arrays.Count; i++)
        {
            maxDistance = Math.Max(maxDistance, Math.Abs(arrays[i][arrays[i].Count - 1] - smallest));
            maxDistance = Math.Max(maxDistance, Math.Abs(largest - arrays[i][0]));
            smallest = Math.Min(smallest, arrays[i][0]);
            largest = Math.Max(largest, arrays[i][arrays[i].Count - 1]);
        }

        return maxDistance;
    }
}
