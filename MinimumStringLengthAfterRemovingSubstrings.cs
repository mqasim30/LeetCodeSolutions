namespace LeetCode.MinimumStringLengthAfterRemovingSubstrings;
public class Solution
{
    public int MinLength(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (stack.Count > 0)
            {
                char top = stack.Peek();
                if ((top == 'A' && c == 'B') || (top == 'C' && c == 'D'))
                {
                    stack.Pop();
                    continue;
                }
            }
            stack.Push(c);
        }
        return stack.Count;
    }
}