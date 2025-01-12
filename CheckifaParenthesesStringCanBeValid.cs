namespace LeetCode.CheckifaParenthesesStringCanBeValid;

public class Solution
{
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 == 1)
            return false;

        var open = 0;
        var close = 0;

        for (var i = 0; i < s.Length; i++)
        {
            open += (s[i] == ')' && locked[i] == '1') ? -1 : 1;
            if (open < 0)
                return false;
        }

        for (var i = s.Length - 1; i >= 0; i--)
        {
            close += (s[i] == '(' && locked[i] == '1') ? -1 : 1;
            if (close < 0)
                return false;
        }

        return true;
    }
}