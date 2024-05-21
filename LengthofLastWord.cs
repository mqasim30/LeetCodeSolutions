namespace LeetCode.LengthofLastWord
{
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            string newString = s.Trim();
            string result = "";
            int lastSpaceIndex = newString.LastIndexOf(' ');

            for (int i = lastSpaceIndex +1; i < newString.Length; i++)
            {
                result += newString[i];
            }
            return result.Length;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         Console.WriteLine(solution.LengthOfLastWord("   fly me   to   the moon  "));
    //         Console.WriteLine(solution.LengthOfLastWord("Hello World"));
    //         Console.WriteLine(solution.LengthOfLastWord("luffy is still joyboy"));   
    //     }
    // }
}