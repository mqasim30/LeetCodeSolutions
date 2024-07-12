namespace LeetCode.MaximumScoreFromRemovingSubstrings;

public class Solution
{
    public int MaximumGain(string s, int x, int y)
    {
        int result = 0;
        if (x >= y)
        {
            result += RemovePairs(ref s, 'a', 'b', x);
            result += RemovePairs(ref s, 'b', 'a', y);
        }
        else
        {
            result += RemovePairs(ref s, 'b', 'a', y);
            result += RemovePairs(ref s, 'a', 'b', x);
        }
        return result;
    }

    private int RemovePairs(ref string s, char first, char second, int score)
    {
        Stack<char> stack = new Stack<char>();
        int points = 0;
        foreach (char c in s)
        {
            if (stack.Count > 0 && stack.Peek() == first && c == second)
            {
                stack.Pop();
                points += score;
            }
            else
            {
                stack.Push(c);
            }
        }
        char[] remaining = stack.ToArray();
        Array.Reverse(remaining);
        s = new string(remaining);
        return points;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string s = "aabbaaxybbaabb";
//         int x = 5, y = 4;
//         Console.WriteLine("Result = " + solution.MaximumGain(s, x, y));
//     }
// }