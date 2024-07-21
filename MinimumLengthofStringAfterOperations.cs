namespace LeetCode.MinimumLengthofStringAfterOperations;

public class Solution
{
    public int MinimumLength(string s)
    {
        var dic = CreateAuxDicFromString(s);
        var rs = 0;
        foreach (var item in dic)
        {
            rs += item.Value % 2 == 0 ? 2 : 1;
        }
        return rs;
    }

    private Dictionary<char, int> CreateAuxDicFromString(string s)
    {
        var rs = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!rs.ContainsKey(s[i]))
            {
                rs.Add(s[i], 1);
            }
            else
            {
                rs[s[i]]++;
            }
        }
        return rs;
    }
}