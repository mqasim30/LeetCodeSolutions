namespace LeetCode.Constain_Duplicate
{
    class Solution
    {
        public int[] nums = [1, 2, 3, 1];
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> numsHS = new HashSet<int>(nums);
            if (numsHS.Count < nums.Length)
            {
                return true;
            }
            return false;
        }
    }

    class Program
    {
        // private static void Main(string[] args)
        // {
        //     Solution solution = new Solution();
        //     Console.WriteLine(solution.ContainsDuplicate(solution.nums));
        // }
    }
}