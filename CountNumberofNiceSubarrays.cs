namespace LeetCode.CountNumberofNiceSubarrays;
public class Solution
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int[] cnt = new int[n + 1];
        cnt[0] = 1;
        int ans = 0, t = 0;
        foreach (int v in nums)
        {
            t += v & 1;
            if (t - k >= 0)
            {
                ans += cnt[t - k];
            }
            cnt[t]++;
        }
        return ans;
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [1, 1, 2, 1, 1];
//         int k = 3;
//         Console.WriteLine(solution.NumberOfSubarrays(nums, k));
//     }
// }
