namespace LeetCode.SearchInsertPosition
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int result = Array.BinarySearch(nums, target);
            if(result < 0)
            {
                result = (int)(MathF.Abs(result) -1);
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [1,3,5,6];
    //         Console.WriteLine(solution.SearchInsert(nums, 2));
    //     }
    // }
}