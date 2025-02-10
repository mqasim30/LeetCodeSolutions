using System.Text;

namespace LeetCode.ClearDigits;

public class Solution
{
    public string ClearDigits(string s)
    {
        StringBuilder result = new();
        foreach (char c in s)
        {
            if (!char.IsDigit(c))
            {
                result.Append(c);
            }
            else
            {
                result.Remove(result.Length - 1, 1);
            }
        }
        return result.ToString();
    }
}