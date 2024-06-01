using System.Xml.XPath;

namespace LeetCode.ScoreofaString
{
    public class Solution
    {
        public int ScoreOfString(string s)
        {
            int back = 0;
            int front = 0;
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                back = i;
                front = back + 1;
                if (back >= s.Length || front >= s.Length)
                {
                    break;
                }
                result += Math.Abs((int)s[back] - (int)s[front]);
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         string s = "zaz";
    //         Console.WriteLine(solution.ScoreOfString(s));
    //     }
    // }
}