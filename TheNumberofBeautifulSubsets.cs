namespace LeetCode.TheNumberofBeautifulSubsets
{
   public class Solution
    {
        public int dfs(int[] nums, int idx, int k, Dictionary<int, int> dict)
        {
            if (idx == nums.Length) return 1;

            int taken = 0;
            if (!dict.ContainsKey(nums[idx] - k) && !dict.ContainsKey(nums[idx] + k))
            {
                dict[nums[idx]] = dict.GetValueOrDefault(nums[idx], 0) + 1;
                taken = dfs(nums, idx + 1, k, dict);
                dict[nums[idx]] = dict[nums[idx]] - 1;
                if (dict[nums[idx]] == 0)
                {
                    dict.Remove(nums[idx]);
                }
            }

            int notTaken = dfs(nums, idx + 1, k, dict);

            return taken + notTaken;
        }

        public int BeautifulSubsets(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int ans = dfs(nums, 0, k, dict);
            return ans - 1;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [2, 4, 6];
    //         int k = 2;
    //         System.Console.WriteLine(solution.BeautifulSubsets(nums, k));

    //     }
    // }
}