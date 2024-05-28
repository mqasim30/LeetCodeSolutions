namespace LeetCode.SpecialArrayWithXElementsGreaterThanorEqualX
{
    class Solution
    {
        public int SpecialArray(int[] nums)
        {
            int[] bucket = new int[1001];
            int total = nums.Length;

            foreach (int num in nums)
            {
                bucket[num]++;
            }
            for (int i = 0; i < 1001; i++)
            {
                if (i == total)
                {
                    return i;
                }
                total -= bucket[i];
            }
            return -1;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [3, 5];
    //         System.Console.WriteLine(solution.SpecialArray(nums));
    //     }
    // }
}