namespace LeetCode.LongestBalancedSubstringI;

public class Solution
{
    public int LongestBalanced(string s)
    {
        int n = s.Length;
        int result = 0;


        for (int i = 0; i < n; i++)
        {
            Dictionary<char, int> mapDict = new Dictionary<char, int>();
            for (int j = i; j < n; j++)
            {
                bool flag = true;
                if (mapDict.ContainsKey(s[j]))
                {
                    mapDict[s[j]] += 1;
                }
                else
                    mapDict.Add(s[j], 1);
                int previous = 0;
                foreach (KeyValuePair<char, int> x in mapDict)
                {
                    if (previous == 0)
                    {
                        previous = x.Value;
                    }
                    else if (previous != x.Value)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result = Math.Max(result, j - i + 1);
                }
            }
        }
        return result;
    }
}