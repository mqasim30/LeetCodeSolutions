namespace LeetCode.FindMostFrequentVowelandConsonant;

public class Solution
{
    public int MaxFreqSum(string s)
    {
        Dictionary<char, int> mp = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            if (mp.ContainsKey(ch))
            {
                mp[ch]++;
            }
            else
            {
                mp[ch] = 1;
            }
        }
        int vowel = 0, consonant = 0;
        for (char ch = 'a'; ch <= 'z'; ch++)
        {
            int count = mp.ContainsKey(ch) ? mp[ch] : 0;
            if (IsVowel(ch))
            {
                vowel = Math.Max(vowel, count);
            }
            else
            {
                consonant = Math.Max(consonant, count);
            }
        }
        return vowel + consonant;
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}