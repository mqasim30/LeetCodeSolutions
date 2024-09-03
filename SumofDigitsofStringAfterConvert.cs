namespace LeetCode.SumofDigitsofStringAfterConvert;
public class Solution
{
    public int GetLucky(string s, int k)
    {
        int r = 0;
        for (int i = 0; i < s.Length; i++)
            r += GetSum(s[i] - 'a' + 1);

        for (int i = 0; i < k - 1; i++)
            r = GetSum(r);

        return r;
    }

    private int GetSum(int x)
    {
        int r = 0;
        while (x > 0)
        {
            r += x % 10;
            x /= 10;
        }

        return r;
    }
}