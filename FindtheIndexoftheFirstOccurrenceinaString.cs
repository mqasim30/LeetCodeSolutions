namespace LeetCode.FindtheIndexoftheFirstOccurrenceinaString
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            char[] chars = needle.ToCharArray();
            int pointer = 0;
            int backTrackIndex = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (pointer == chars.Length)
                {
                    return i - pointer;
                }
                if (pointer < chars.Length && haystack[i] == chars[pointer])
                {
                    if (haystack[i] == chars[0] && pointer != 0 && backTrackIndex == 0 && pointer != chars.Length)
                    {
                        backTrackIndex = i;
                    }
                    pointer++;
                }
                else
                {
                    if (haystack[i] == chars[0] && pointer != 0 && backTrackIndex == 0 && pointer != chars.Length)
                    {
                        backTrackIndex = i;
                    }
                    if (backTrackIndex != 0)
                    {
                        i = backTrackIndex - 1;
                        backTrackIndex = 0;
                    }
                    pointer = 0;
                }

            }
            if (pointer == chars.Length)
            {
                return haystack.Length - pointer;
            }
            return -1;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         System.Console.WriteLine(solution.StrStr("sadbutsad", "sad"));
    //         System.Console.WriteLine(solution.StrStr("leetcode", "leeto"));
    //         System.Console.WriteLine(solution.StrStr("thisisasamplestringwearegoingtotest", "test"));
    //         System.Console.WriteLine(solution.StrStr("thisisasamplestringwearegoingtotest", "we"));
    //         System.Console.WriteLine(solution.StrStr("mississippi", "issip"));
    //         System.Console.WriteLine(solution.StrStr("mississippi", "pi"));
    //         Console.WriteLine(solution.StrStr("aabaaabaaac", "aabaaac"));
    //     }
    // }
}