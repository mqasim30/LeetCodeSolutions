namespace LeetCode.MinimumOperationstoMakeBinaryArrayElementsEqualtoOneII;

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int result = 0;
        bool flipped = false;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0 && !flipped)
            {
                Console.WriteLine($"Found 0 at: {i}");
                flipped = !flipped;
                result++;
            }
            if (nums[i] == 1 && flipped)
            {
                Console.WriteLine($"Found 1 at: {i}");
                flipped = !flipped;
                result++;
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
//         int[] nums = [0, 1, 1, 0, 1];
//         solution.MinOperations(nums);
//     }
// }