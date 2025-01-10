namespace LeetCode.WordSubsets;

public class Solution
{
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        var requiredChars = CombineRequirements(words2);

        var result = new List<string>();

        foreach (var word in words1)
        {
            if (IsUniversal(word, requiredChars))
            {
                result.Add(word);
            }
        }

        return result;
    }
    private Dictionary<char, int> CombineRequirements(string[] words2)
    {
        var charRequirements = new Dictionary<char, int>();

        foreach (var word in words2)
        {
            var wordCount = GetCharCount(word);

            foreach (var kvp in wordCount)
            {
                if (!charRequirements.ContainsKey(kvp.Key))
                {
                    charRequirements[kvp.Key] = kvp.Value;
                }
                else
                {
                    charRequirements[kvp.Key] = Math.Max(charRequirements[kvp.Key], kvp.Value);
                }
            }
        }

        return charRequirements;
    }
    private bool IsUniversal(string word, Dictionary<char, int> requiredChars)
    {
        var wordCount = GetCharCount(word);

        foreach (var kvp in requiredChars)
        {
            if (!wordCount.ContainsKey(kvp.Key) || wordCount[kvp.Key] < kvp.Value)
            {
                return false;
            }
        }

        return true;
    }
    private Dictionary<char, int> GetCharCount(string word)
    {
        var charCount = new Dictionary<char, int>();

        foreach (var c in word)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        return charCount;
    }
}