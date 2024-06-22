namespace LeetCode.MinimumOperationstoMakeBinaryArrayElementsEqualtoOneI;

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] == 0)
            {
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                result++;
            }
        }

        if (nums.Contains(0))
        {
            return -1;
        }
        else
            return result;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();

//         int[] nums1 = { 0, 0, 0, 1 };
//         int[] nums2 = { 1, 0, 1, 0, 0 };
//         int[] nums3 = { 1, 1, 1 };
//         int[] nums4 = { 0, 1, 0, 1, 0, 1, 0, 1 };
//         int[] nums5 = { 1, 0, 0, 1, 1, 0, 1, 1, 1 };

//         Console.WriteLine(solution.MinOperations(nums1)); // Output: 1
//         Console.WriteLine(solution.MinOperations(nums2)); // Output: -1
//         Console.WriteLine(solution.MinOperations(nums3)); // Output: 0
//         Console.WriteLine(solution.MinOperations(nums4)); // Output: -1
//         Console.WriteLine(solution.MinOperations(nums5)); // Output: -1
//     }
// }
