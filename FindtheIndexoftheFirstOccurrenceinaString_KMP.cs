namespace LeetCode.FindtheIndexoftheFirstOccurrenceinaString_KMP
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle == "")
            {
                return 0;
            }
            int[] LPS = CalculateLPS(needle);

            int i = 0, j = 0;

            while (i < haystack.Length)
            {
                if (haystack[i] == needle[j])
                {
                    i += 1;
                    j += 1;
                }
                else
                {
                    if (j == 0)
                    {
                        i++;
                    }
                    else
                    {
                        j = LPS[j - 1];
                    }
                }
                if( j == needle.Length)
                {
                    return i - needle.Length;
                }
            }

            return -1;
        }
        public int[] CalculateLPS(string String)
        {
            int prevLPS = 0;
            int index = 1;
            int[] LPS = Enumerable.Repeat(0, String.Length).ToArray();
            while (index < String.Length)
            {
                if (String[index] == String[prevLPS])
                {
                    LPS[index] = prevLPS + 1;
                    prevLPS += 1;
                    index += 1;
                }
                else if (prevLPS == 0)
                {
                    LPS[index] = 0;
                    index += 1;
                }
                else
                {
                    prevLPS = LPS[prevLPS - 1];
                }
            }
            return LPS;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         Console.WriteLine(solution.StrStr("aaaaaaaacaaaaaaaa", "aaacaaaa"));
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