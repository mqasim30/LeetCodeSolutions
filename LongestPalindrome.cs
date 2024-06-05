namespace LeetCode.LongestPalindrome
{
    public class Solution
    {
        public int LongestPalindrome(string s)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            int result = 0;
            foreach (char c in s)
            {
                if (keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs[c] += 1;
                }
                else
                {
                    keyValuePairs[c] = 1;
                }
                if (keyValuePairs[c] % 2 == 0)
                {
                    result += 2;
                }
            }
            foreach (var item in keyValuePairs.Values)
            {
                if (item % 2 == 1)
                {
                    result += 1;
                    break;
                }
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         string s = "abccccdd";
    //         Console.WriteLine(solution.LongestPalindrome(s));
    //     }
    // }
}