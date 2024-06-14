namespace LeetCode.MinimumIncrementtoMakeArrayUnique;

public class Solution
{
    public int MinIncrementForUnique(int[] nums)
    {
        int result = 0;
        int pointerBack = 0;
        int pointerFront = 1;
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++)
        {
            Console.WriteLine($"Checking {nums[pointerBack]}, {nums[pointerFront]}");
            if (nums[pointerBack] == nums[pointerFront])
            {
                Console.WriteLine("Found Equal");
                nums[pointerFront] += 1;
                result += 1;
            }
            else if (nums[pointerBack] > nums[pointerFront])
            {
                Console.WriteLine("Found Greater");
                int temp = nums[pointerBack] - nums[pointerFront];
                result += 1 + temp;
                nums[pointerFront] += temp;
                nums[pointerFront] += 1;

            }
            pointerBack += 1;
            pointerFront += 1;
        }
        foreach (var item in nums)
        {
            Console.WriteLine(item);
        }
        return result;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [3, 2, 1, 2, 1, 7];
        Console.WriteLine(solution.MinIncrementForUnique(nums));
    }
}
