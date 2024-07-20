using System;
using System.Collections.Generic;
// public class Solution
// {
//     public string LosingPlayer(int x, int y)
//     {
//         int maxMoves = Math.Min(x, y / 4);
//         if (maxMoves % 2 == 0)
//         {
//             return "Bob";
//         }
//         else
//         {
//             return "Alice";
//         }
//     }
// }



// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int x = 2, y = 7;
//         //int x = 4, y = 11;
//         System.Console.WriteLine(solution.LosingPlayer(x, y));
//     }
// }


public class Solution
{
    public int MinimumLength(string s)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        // Count the occurrences of each character
        foreach (char c in s)
        {
            if (!charCount.ContainsKey(c))
            {
                charCount[c] = 0;
            }
            charCount[c]++;
        }

        int maxCount = charCount.Values.Max();
        int totalCount = s.Length;

        // If the most frequent character appears more than half the time,
        // it will determine the minimum length
        if (maxCount > totalCount / 2)
        {
            return 2 * maxCount - totalCount;
        }

        // Otherwise, we can remove pairs until we have 0 or 1 character left
        return totalCount % 2;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        //string s = "abaacbcbb";
        //string s = "ucvbutgkohgbcobqeyqwppbxqoynxeuuzouyvmydfhrprdbuzwqebwuiejoxsxdhbmuaiscalnteocghnlisxxawxgcjloevrdcj";
        string s = "aa";
        System.Console.WriteLine(solution.MinimumLength(s));
    }
}