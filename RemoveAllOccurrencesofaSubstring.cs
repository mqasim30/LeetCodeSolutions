using System.Text;

namespace LeetCode.RemoveAllOccurrencesofaSubstring;

public class Solution
{
    public string RemoveOccurrences(string s, string part)
    {
        StringBuilder sb = new StringBuilder(s);
        int partLength = part.Length;

        int index;
        while ((index = sb.ToString().IndexOf(part)) != -1)
        {
            sb.Remove(index, partLength);
        }

        return sb.ToString();
    }
}