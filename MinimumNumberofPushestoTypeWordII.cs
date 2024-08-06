namespace LeetCode.MinimumNumberofPushestoTypeWordII;
public class Solution
{
    public int MinimumPushes(string word)
    {
        int[] letterFrequency = new int[26];
        foreach (char c in word)
        {
            letterFrequency[c - 'a']++;
        }

        var sortedFreq = letterFrequency.OrderByDescending(f => f).ToArray();

        int totalPresses = 0;
        for (int i = 0; i < 26; i++)
        {
            if (sortedFreq[i] == 0) break;
            totalPresses += (i / 8 + 1) * sortedFreq[i];
        }

        return totalPresses;
    }
}
