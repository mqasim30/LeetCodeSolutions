namespace LeetCode.NumberofSubsequencesThatSatisfytheGivenSumCondition;

public class Solution
{
    public int NumSubseq(int[] nums, int target)
    {
        // Sort the array in non-decreasing order
        Array.Sort(nums);

        // Initialize variables
        int mod = 1000000007;
        int n = nums.Length;
        int ans = 0;

        // Calculate powers of 2 modulo mod
        int[] pow2 = new int[n];
        pow2[0] = 1;
        for (int i = 1; i < n; i++)
        {
            pow2[i] = (pow2[i - 1] * 2) % mod;
        }

        // Use two pointers to find subsequences
        int left = 0, right = n - 1;
        while (left <= right)
        {
            // If the sum of the minimum and maximum values is less than or equal to target,
            // add the number of subsequences of length (right - left) to the answer
            if (nums[left] + nums[right] <= target)
            {
                ans = (ans + pow2[right - left]) % mod;
                left++;
            }
            // Otherwise, move the right pointer to the left
            else
            {
                right--;
            }
        }

        return ans;
    }
}