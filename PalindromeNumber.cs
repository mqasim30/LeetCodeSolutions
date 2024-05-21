namespace LeetCode.PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            char[] chars = x.ToString().ToCharArray();
            char[] reverse = new char[chars.Length];
            Array.Copy(chars, reverse, chars.Length);
            Array.Reverse(reverse);
            string original =  new string(chars);
            string reversed  = new string(reverse);
            if(original == reversed)
            {
                return true;
            }
            return false;
        }

        // public static void Main(string[] args)
        // {
        //     Solution solution = new Solution();

        //     bool answer = solution.IsPalindrome(-121);
        //     Console.WriteLine(answer);
        // }
    }
}