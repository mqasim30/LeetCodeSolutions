namespace LeetCode.MinimumDeletionstoMakeStringKSpecial;

public class Solution
{
    public int MinimumDeletions(string word, int k)
    {
        Dictionary<char, int> cnt = new Dictionary<char, int>();
        foreach (char ch in word)
        {
            if (cnt.ContainsKey(ch))
            {
                cnt[ch]++;
            }
            else
            {
                cnt[ch] = 1;
            }
        }
        int res = word.Length;
        foreach (int a in cnt.Values)
        {
            int deleted = 0;
            foreach (int b in cnt.Values)
            {
                if (a > b)
                {
                    deleted += b;
                }
                else if (b > a + k)
                {
                    deleted += b - (a + k);
                }
            }
            res = Math.Min(res, deleted);
        }
        return res;
    }
}