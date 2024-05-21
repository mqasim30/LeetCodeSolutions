namespace LeetCode.Subsets
{
    public class Solution
    {
        List<IList<int>> result = new List<IList<int>>();

        public IList<IList<int>> Subsets(int[] nums)
        {
            backtrack(nums, 0, new List<int>(), result);
            return result;
        }
        private void backtrack(int[] nums, int start, List<int> path, List<IList<int>> result)
        {
            result.Add(new List<int>(path));
            for (int i = start; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                backtrack(nums, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //     }
    // }
}