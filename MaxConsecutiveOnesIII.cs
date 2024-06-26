namespace LeetCode.MaxConsecutiveOnesIII;

public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int maxLength = 0, left = 0, right = 0, zeroCount = 0;
        while (right < nums.Length)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
            }
            while (zeroCount > k)
            {
                if (nums[left] == 0)
                {
                    zeroCount -= 1;
                }
                left++;
            }

            int length = right - left + 1;
            maxLength = Math.Max(maxLength, length);
            right++;
        }
        return maxLength;
    }
}


// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1];
//         int k = 3;
//         Console.WriteLine(solution.LongestOnes(nums, k));
//     }
// }
