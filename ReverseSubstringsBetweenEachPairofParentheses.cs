namespace LeetCode.ReverseSubstringsBetweenEachPairofParentheses;

public class Solution
{
    public string ReverseParentheses(string s)
    {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in s)
        {
            if (c != ')')
            {
                stack.Push(c);
            }
            else
            {
                List<char> word = new List<char>();                
                while (stack.Peek() != '(')
                {
                    word.Add(stack.Pop());
                }
                stack.Pop();                
                foreach (char item in word)
                {
                    stack.Push(item);
                }
            }
        }
        var answer = stack.Reverse();
        return new string(answer.ToArray());
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string s = "(ed(et(oc))el)";
//         Console.WriteLine("Result = " + solution.ReverseParentheses(s));
//     }
// }