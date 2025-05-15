namespace LeetCode.LongestUnequalAdjacentGroupsSubsequenceI;
public class Solution
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) => words.
        Select((m, i) => (m, i)).
        Where(m => m.i == 0 || groups[m.i] != groups[m.i - 1]).
        Select(m => m.m).
        ToList();
}