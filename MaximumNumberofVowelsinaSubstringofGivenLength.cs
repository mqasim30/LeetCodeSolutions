namespace LeetCode.MaximumNumberofVowelsinaSubstringofGivenLength;

public class Solution
{
    HashSet<char> chars = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

    public int MaxVowels(string s, int k)
    {
        int sumOfVowels = 0;
        for (int i = 0; i < k; i++)
        {
            if (chars.Contains(s[i]))
            {
                sumOfVowels += 1;
            }
        }
        int maxSumOfVowels = sumOfVowels;
        for (int i = k; i < s.Length; i++)
        {
            if (chars.Contains(s[i - k]))
            {
                sumOfVowels -= 1;
            }

            if (chars.Contains(s[i]))
            {
                sumOfVowels += 1;
            }
            maxSumOfVowels = Math.Max(maxSumOfVowels, sumOfVowels);
        }
        return maxSumOfVowels;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string s = "leetcode";
//         int k = 3;
//         Console.WriteLine(solution.MaxVowels(s, k));
//     }
// }
