using System.Text;

namespace LeetCode.ReverseWordsinaString;

public class Solution
{
    public string ReverseWords(string s)
    {
        s = s.Trim();

        string[] words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);

        StringBuilder result = new StringBuilder();

        foreach (var word in words)
        {
            result.Append(word);
            result.Append(' ');
        }

        return result.ToString().TrimEnd();
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string s = "a good   example";
//         System.Console.WriteLine(solution.ReverseWords(s));
//     }
// }