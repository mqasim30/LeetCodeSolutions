namespace LeetCode.MinimumNumberofChangestoMakeStringBeautiful;

class Solution
{
    public int MinChanges(String s)
    {
        int ans = 0;
        for (int i = 0; i < s.Length; i += 2)
        {
            if (s[i] != s[i + 1])
                ans++;
        }
        return ans;
    }
}