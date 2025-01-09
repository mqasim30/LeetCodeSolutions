namespace LeetCode.CountingWordsWithaGivenPrefix;

public class Solution
{
    public int CountWordsWithPrefix(string[] words, string prefix)
    {
        var prefixSet = new HashSet<string>();
        int count = 0;

        foreach (var word in words)
        {
            for (int len = 1; len <= word.Length; len++)
            {
                prefixSet.Add(word.Substring(0, len));
            }
        }
        foreach (var word in words)
        {
            if (prefixSet.Contains(prefix) && word.StartsWith(prefix))
            {
                count++;
            }
        }

        return count;
    }
}