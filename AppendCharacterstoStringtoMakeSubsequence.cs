namespace LeetCode.AppendCharacterstoStringtoMakeSubsequence
{
    public class Solution
    {
        public int AppendCharacters(string s, string t)
        {
            int pt = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (pt < t.Length && t[pt] == s[i])
                {
                    pt += 1;
                }
            }
            return t.Length - pt;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         string s = "coaching";
    //         string t = "coding";
    //         Console.WriteLine(solution.AppendCharacters(s, t));
    //     }
    // }
}