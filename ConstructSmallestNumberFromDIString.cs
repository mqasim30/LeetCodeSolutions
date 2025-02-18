namespace LeetCode.ConstructSmallestNumberFromDIString;

public class Solution
{
    public string SmallestNumber(string pattern)
    {
        var result = new List<int>();
        var stack = new Stack<int>();
        for (int i = 0; i <= pattern.Length; i++)
        {
            stack.Push(i + 1);
            if (i == pattern.Length || pattern[i] == 'I')
            {
                while (stack.Count > 0)
                {
                    result.Add(stack.Pop());
                }
            }
        }

        return string.Join("", result);

    }
}