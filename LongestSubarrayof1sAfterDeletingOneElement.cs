namespace LeetCode.LongestSubarrayof1sAfterDeletingOneElement;

public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int maxLength = 0, left = 0, right = 0, zeroCount = 0;
        while (right < nums.Length)
        {
            if (nums[right] == 0)
            {
                zeroCount += 1;
            }

            while (zeroCount > 1)
            {
                if (nums[left] == 0)
                {
                    zeroCount -= 1;
                }
                left++;
            }
            right++;
            int length = right - left;
            maxLength = Math.Max(maxLength, length);
        }
        if (zeroCount == 0)
        {
            return maxLength - 1;
        }
        return maxLength - zeroCount;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [0, 1, 1, 1, 0, 0, 0, 0, 1];
//         Console.WriteLine(solution.LongestSubarray(nums));
//     }
// }
