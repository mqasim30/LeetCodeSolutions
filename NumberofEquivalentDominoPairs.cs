namespace LeetCode.NumberofEquivalentDominoPairs;

public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var counts = new Dictionary<int, int>();
        foreach (var domino in dominoes)
        {
            var index = Math.Min(domino[0], domino[1]) * 10 + Math.Max(domino[0], domino[1]);
            if (!counts.ContainsKey(index))
                counts[index] = 1;
            else
                counts[index]++;
        }

        var result = 0;
        foreach (var value in counts.Values)
            result += value * (value - 1) / 2;

        return result;
    }
}