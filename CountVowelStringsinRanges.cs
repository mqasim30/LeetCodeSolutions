namespace LeetCode.CountVowelStringsinRanges;

public class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        bool IsVowelWord(string word)
        {
            char first = word[0];
            char last = word[^1];
            return IsVowel(first) && IsVowel(last);
        }

        bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        int n = words.Length;
        int[] prefixCount = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixCount[i + 1] = prefixCount[i] + (IsVowelWord(words[i]) ? 1 : 0);
        }

        int q = queries.Length;
        int[] results = new int[q];
        for (int i = 0; i < q; i++)
        {
            int li = queries[i][0];
            int ri = queries[i][1];
            results[i] = prefixCount[ri + 1] - prefixCount[li];
        }

        return results;
    }
}