namespace LeetCode.RankTransformofanArray;

public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        var sortedArray = new int[arr.Length];
        arr.CopyTo(sortedArray, 0);

        Array.Sort(sortedArray);
        var ranks = new Dictionary<int, int>();

        for (int i = 0; i < sortedArray.Length; i++)
        {
            if (!ranks.TryGetValue(sortedArray[i], out var _))
                ranks[sortedArray[i]] = ranks.Count + 1;
        }

        var result = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            result[i] = ranks[arr[i]];

        return result;
    }
}