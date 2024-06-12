namespace LeetCode.SortColors;

public class Solution
{
    public void SortColors(int[] nums)
    {
        int zeroCount = 0;
        int oneCount = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroCount += 1;
            }
            else if (nums[i] == 1)
            {
                oneCount += 1;
            }
        }

        for (int i = 0; i < zeroCount; i++)
        {
            nums[i] = 0;
        }

        for (int i = zeroCount; i < oneCount + zeroCount; i++)
        {
            nums[i] = 1;
        }

        for (int i = oneCount + zeroCount; i < nums.Length; i++)
        {
            nums[i] = 2;
        }

        foreach (var item in nums)
        {
            Console.WriteLine(item);
        }
    }
}


// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [2, 0, 2, 1, 1, 0];
//         solution.SortColors(nums);
//     }
// }
