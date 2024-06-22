using System.Text;

namespace LeetCode.MergeStringsAlternately;

public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        StringBuilder result = new StringBuilder();
        int index = 0;
        for (index = 0; index < Math.Min(word1.Length, word2.Length); index++)
        {
            if (index < word1.Length)
            {
                result.Append(word1[index]);
            }

            if (index < word2.Length)
            {
                result.Append(word2[index]);
            }
        }
        if (word1.Length > word2.Length)
        {
            result.Append(word1.Substring(index));
        }
        else if (word1.Length < word2.Length)
        {
            result.Append(word2.Substring(index));
        }
        return result.ToString();
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         //string word1 = "abc", word2 = "pqr";
//         string word1 = "ab", word2 = "pqrs";
//         //string word1 = "abcd", word2 = "pq";
//         Console.WriteLine(solution.MergeAlternately(word1, word2));
//     }
// }