namespace LeetCode.SortArraybyIncreasingFrequency;

public class Solution {
    public int[] FrequencySort(int[] nums) =>
        nums.GroupBy(v => v)
            .OrderBy(g => g.Count())
            .ThenByDescending(g => g.Key)
            .SelectMany(g => g)
            .ToArray();
}