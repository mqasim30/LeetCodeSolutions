namespace LeetCode.PartitionLabels;

public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        int[] freqcharacters = new int[26];
        for (int i = 0; i < s.Length; i++)
            freqcharacters[s[i] - 'a']++;

        List<int> ans = new();
        int lastidx = 0;
        for (int i = 0; i < s.Length;)
        {
            Dictionary<char, int> cache = new();
            while (i < s.Length)
            {
                char c = s[i++];
                if (!cache.ContainsKey(c))
                {
                    cache.Add(c, freqcharacters[c - 'a'] - 1);
                }
                else cache[c]--;

                bool f = true;
                foreach (var item in cache)
                    if (item.Value != 0) { f = false; break; }

                if (f) break;
            }
            ans.Add(i - lastidx);
            lastidx = i;
        }
        return ans;
    }
}