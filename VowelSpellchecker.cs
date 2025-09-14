using System.Text;

namespace LeetCode.VowelSpellchecker;

public class Solution
{
    private HashSet<char> vows = new HashSet<char>("aeiouAEIOU");
    private string MaskVow(string s)
    {
        StringBuilder sb = new StringBuilder(s);
        for (int i = 0; i < sb.Length; i++)
        {
            if (vows.Contains(sb[i]))
                sb[i] = '*';
        }

        return sb.ToString();
    }
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        HashSet<string> wordSet = new HashSet<string>(wordlist);

        Dictionary<string, string> caseInsensDict = new();
        Dictionary<string, string> mask = new();
        foreach (string w in wordlist)
        {
            string s = w.ToLower();
            if (!caseInsensDict.ContainsKey(s))
                caseInsensDict.Add(s, w);

            string t = MaskVow(s);
            if (t != s && !mask.ContainsKey(t))
                mask.Add(t, w);
        }

        int qLen = queries.Length;
        string[] res = new string[qLen];
        for (int i = 0; i < qLen; i++)
        {
            string s = queries[i];
            string t = "";
            if (wordSet.Contains(s))
                t = s;
            else
            {
                string sInsens = s.ToLower();
                if (caseInsensDict.ContainsKey(sInsens))
                    t = caseInsensDict[sInsens];
                else
                {
                    string sMask = MaskVow(sInsens);

                    if (mask.ContainsKey(sMask))
                        t = mask[sMask];
                }
            }

            res[i] = t;
        }

        return res;
    }
}