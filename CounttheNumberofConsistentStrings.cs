namespace LeetCode.CounttheNumberofConsistentStrings;
public class Solution
{
    public int CountConsistentStrings(string allowed, string[] words)
    {
        bool[] chars = new bool[26];
        foreach (char ch in allowed)
        {
            int idx = ch - 'a';
            chars[idx] = true;
        }
        bool flag = true;
        int cnt = 0;
        foreach (string str in words)
        {
            flag = true;
            foreach (char ch in str)
            {
                if (chars[ch - 'a'] == false)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                cnt++;
        }
        return cnt;
    }
}