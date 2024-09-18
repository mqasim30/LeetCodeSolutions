namespace LeetCode.UncommonWordsfromTwoSentences;

public class Solution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        List<string> ans = new List<string>();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string[] dict1 = s1.Split(' ');
        string[] dict2 = s2.Split(' ');
        foreach (var word in dict1)
        {
            if (dict.ContainsKey(word))
                dict[word]++;
            else
                dict[word] = 1;
        }
        foreach (var word in dict2)
        {
            if (dict.ContainsKey(word))
                dict[word]++;
            else
                dict[word] = 1;
        }
        foreach (var (key, val) in dict)
        {
            if (val == 1)
                ans.Add(key);
        }
        return ans.ToArray();
    }
}