namespace LeetCode.ConstructKPalindromeStrings;

public class Solution
{
    public bool CanConstruct(string s, int k)
    {
        if (k > s.Length)
        {
            return false;
        }

        int[] charCount = new int[26];
        foreach (char c in s)
        {
            charCount[c - 'a']++;
        }

        int oddCount = 0;
        foreach (int count in charCount)
        {
            if (count % 2 != 0)
            {
                oddCount++;
            }
        }

        return oddCount <= k;
    }
}