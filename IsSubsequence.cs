namespace LeetCode.IsSubsequence;

public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        int left = 0;

        for (int right = 0; right < t.Length; right++)
        {
            if (left < s.Length)
            {
                if (s[left] == t[right])
                {
                    left++;
                }
            }
            else
            {
                return true;
            }
        }
        Console.WriteLine(left);

        if (left == s.Length)
        {
            return true;
        }

        return false;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "axc", t = "ahbgdc";
        System.Console.WriteLine(solution.IsSubsequence(s, t));
    }
}
