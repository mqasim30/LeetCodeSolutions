namespace LeetCode.LongestCommonPrefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            if (strs.Length == 0)
            {
                return result;
            }
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if(strs[j][i] != strs[0][i])
                    {
                        return result;
                    }
                }
                result += strs[0][i];
            }

            return result;
        }

        // public static void Main(string[] args)
        // {
        //     Solution solution = new Solution();
        //     string[] strs = ["cir", "car"];
        //     Console.WriteLine(solution.LongestCommonPrefix(strs));
        // }
    }
}