namespace LeetCode.UniqueLength3PalindromicSubsequences;

public class Solution
{
    public int CountPalindromicSubsequence(string s)
    {
        int count = 0;
        for (char endsLetter = 'a'; endsLetter <= 'z'; endsLetter++)
        {
            int left = s.IndexOf(endsLetter);
            if (left >= 0)
            {
                int right = s.LastIndexOf(endsLetter);
                int midMask = 0;
                for (int mid = left + 1; mid < right; mid++)
                {
                    midMask |= 1 << s[mid];
                }
                count += int.PopCount(midMask);
            }
        }
        return count;
    }
}