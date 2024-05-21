namespace LeetCode.ValidPalindrome
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]");
            s = regex.Replace(s, "");
            s= s.ToLower();
            char[] reversed = s.ToCharArray();
            Array.Reverse(reversed);
            string reversedString = new string(reversed);
            if(s == reversedString){
                return true;
            }
            return false;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         System.Console.WriteLine(solution.IsPalindrome(" "));
    //     }
    // }
}