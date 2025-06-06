using System.Text;

namespace LeetCode.UsingaRobottoPrinttheLexicographicallySmallestString;

public class Solution
{
    public string RobotWithString(string s)
    {
        int[] cnt = new int[26];
        foreach (char c in s)
        {
            cnt[c - 'a']++;
        }

        Stack<char> stack = new Stack<char>();
        StringBuilder res = new StringBuilder();
        char minCharacter = 'a';
        foreach (char c in s)
        {
            stack.Push(c);
            cnt[c - 'a']--;
            while (minCharacter != 'z' && cnt[minCharacter - 'a'] == 0)
            {
                minCharacter++;
            }
            while (stack.Count > 0 && stack.Peek() <= minCharacter)
            {
                res.Append(stack.Pop());
            }
        }

        return res.ToString();
    }
}