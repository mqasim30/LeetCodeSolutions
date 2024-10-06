namespace LeetCode.SentenceSimilarityIII;

public class Solution
{
    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        string[] words1 = sentence1.Split(' ');
        string[] words2 = sentence2.Split(' ');

        if (Enumerable.SequenceEqual(words1, words2)) return true;

        List<string> prefix = new List<string>();
        List<string> suffix = new List<string>();
        int n = words1.Length, m = words2.Length;

        for (int i = 0; i < Math.Min(n, m); i++)
        {
            if (words1[i] == words2[i])
            {
                prefix.Add(words1[i]);
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < Math.Min(n, m); i++)
        {
            if (words1[n - i - 1] == words2[m - i - 1])
            {
                suffix.Add(words1[n - i - 1]);
            }
            else
            {
                break;
            }
        }

        suffix.Reverse();

        while (suffix.Count + prefix.Count > Math.Min(n, m))
        {
            if (suffix.Count > 0 && prefix.Count > 0 && suffix[0] == prefix[prefix.Count - 1])
            {
                prefix.RemoveAt(prefix.Count - 1);
            }
            else
            {
                break;
            }
        }


        prefix.AddRange(suffix);


        return Enumerable.SequenceEqual(prefix, words1) || Enumerable.SequenceEqual(prefix, words2);
    }
}