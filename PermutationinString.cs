namespace LeetCode.PermutationinString;

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in s1)
        {
            if (!charCount.ContainsKey(c))
            {
                charCount[c] = 0;
            }
            charCount[c]++;
        }

        int start = 0, matched = 0;

        for (int end = 0; end < s2.Length; end++)
        {
            char rightChar = s2[end];

            if (charCount.ContainsKey(rightChar))
            {
                charCount[rightChar]--;

                if (charCount[rightChar] == 0)
                {
                    matched++;
                }
            }

            if (matched == charCount.Count)
            {
                return true;
            }

            if (end >= s1.Length - 1)
            {
                char leftChar = s2[start];
                start++;

                if (charCount.ContainsKey(leftChar))
                {
                    if (charCount[leftChar] == 0)
                    {
                        matched--;
                    }
                    charCount[leftChar]++;
                }
            }
        }

        return false;
    }
}