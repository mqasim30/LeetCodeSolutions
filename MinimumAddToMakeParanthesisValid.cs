namespace LeetCode.MinimumAddToMakeParanthesisValid;
public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        int open = 0, mismatch = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                open++;
            else
            {
                if (open > 0)
                    open--;
                else
                    mismatch++;
            }
        }
        return open + mismatch;
    }
}