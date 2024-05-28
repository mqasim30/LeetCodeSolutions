namespace LeetCode.GetEqualSubStringsWithinBudget
{
    public class Solution
    {
        public int EqualSubstring(string s, string t, int maxCost)
        {
            int n = s.Length;
            int ans = 0, window = 0, left = 0;
            for (int right = 0; right < n; right++)
            {
                window += Math.Abs(s[right] - t[right]);
                while (window > maxCost)
                {
                    window -= Math.Abs(s[left] - t[left]);
                    left++;
                }
                ans = Math.Max(ans, right - left + 1);
            }
            return ans;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         string s = "abcd";
    //         string t = "bcdf";
    //         int maxCost = 3;
    //         solution.EqualSubstring(s,t,maxCost);
    //     }
    // }
}