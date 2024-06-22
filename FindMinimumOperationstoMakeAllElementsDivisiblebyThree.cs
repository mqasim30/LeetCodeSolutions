namespace LeetCode.FindMinimumOperationstoMakeAllElementsDivisiblebyThree;

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 3 != 0)
            {
                Console.WriteLine("Found: " + nums[i]);
                if ((nums[i] + 1) % 3 == 0)
                {
                    Console.WriteLine("Adding");
                    result += 1;
                }
                else if ((nums[i] - 1) % 3 == 0)
                {
                    Console.WriteLine("Subtracting");
                    result += 1;
                }
            }
        }
        return result;
    }
}
// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [1, 1, 2, 1, 1];

//         Console.WriteLine(solution.MinimumOperations(nums));
//     }
// }
