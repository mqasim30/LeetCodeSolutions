namespace LeetCode.CountofSubstringContainingEveryVowelandKConsonantsII;

public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        return AtLeastK(word, k) - AtLeastK(word, k + 1);
    }

    private long AtLeastK(string word, int k)
    {
        int n = word.Length;
        long numValidSubstrings = 0;
        int start = 0, end = 0, consonantCount = 0;
        Dictionary<char, int> vowelCount = new Dictionary<char, int>();

        bool IsVowel(char c)
        {
            return "aeiou".IndexOf(c) != -1;
        }

        while (end < n)
        {
            char newLetter = word[end];

            if (IsVowel(newLetter))
            {
                if (!vowelCount.ContainsKey(newLetter)) vowelCount[newLetter] = 0;
                vowelCount[newLetter]++;
            }
            else
            {
                consonantCount++;
            }

            while (vowelCount.Count == 5 && consonantCount >= k)
            {
                numValidSubstrings += (n - end);

                char startLetter = word[start];

                if (IsVowel(startLetter))
                {
                    vowelCount[startLetter]--;
                    if (vowelCount[startLetter] == 0) vowelCount.Remove(startLetter);
                }
                else
                {
                    consonantCount--;
                }

                start++;
            }

            end++;
        }

        return numValidSubstrings;
    }
}