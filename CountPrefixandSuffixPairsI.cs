namespace LeetCode.CountPrefixandSuffixPairsI;

public class Solution
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        var prefixSuffixSet = new HashSet<string>();
        int count = 0;

        foreach (var word in words)
        {
            for (int len = 1; len <= word.Length; len++)
            {
                prefixSuffixSet.Add(word.Substring(0, len));
                prefixSuffixSet.Add(word.Substring(word.Length - len));
            }
        }
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (prefixSuffixSet.Contains(words[j]) &&
                    words[j].StartsWith(words[i]) &&
                    words[j].EndsWith(words[i]))
                {
                    count++;
                }
            }
        }

        return count;
    }
}