namespace LeetCode.NumberofSubstringsContainingAllThreeCharacters;

public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;
        int numValidSubstrings = 0;
        int start = 0, end = 0;
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        while (end < n)
        {
            char newLetter = s[end];

            if (!charCount.ContainsKey(newLetter)) charCount[newLetter] = 0;
            charCount[newLetter]++;

            while (charCount.Count == 3)
            {
                numValidSubstrings += (n - end);

                char startLetter = s[start];

                charCount[startLetter]--;
                if (charCount[startLetter] == 0) charCount.Remove(startLetter);

                start++;
            }

            end++;
        }

        return numValidSubstrings;
    }
}