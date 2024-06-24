namespace LeetCode.MinimumNumberofKConsecutiveBitFlips;

public class Solution
{
    public int MinKBitFlips(int[] nums, int k)
    {
        int ans = 0, flips = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if ((nums[i] + flips) % 2 == 0)
            {
                if (i > nums.Length - k)
                {
                    return -1;
                }
                else
                {
                    ans++;
                    flips++;
                    nums[i] = -1;
                }
            }
            if (i + 1 >= k)
            {
                flips -= (nums[i - k + 1] < 0 ? 1 : 0);
            }
        }
        return ans;
    }
}


// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [0, 1, 0];
//         int k = 1;
//         Console.WriteLine(solution.MinKBitFlips(nums, k));
//     }
// }

