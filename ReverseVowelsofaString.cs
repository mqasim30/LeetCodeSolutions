namespace LeetCode.ReverseVowelsofaString;

public class Solution
{
    public string ReverseVowels(string s)
    {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        List<(char vowel, int index)> vowelList = new List<(char, int)>();

        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                vowelList.Add((s[i], i));
            }
        }

        char[] chars = s.ToCharArray();

        for (int i = 0; i < vowelList.Count; i++)
        {
            chars[vowelList[i].index] = vowelList[vowelList.Count - 1 - i].vowel;
        }

        return new string(chars);
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string s = "leetcode";
//         System.Console.WriteLine(solution.ReverseVowels(s));
//     }
// }