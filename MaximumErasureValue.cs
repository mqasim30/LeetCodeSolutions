namespace LeetCode.MaximumErasureValue;

public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        int maxSum = 0, currentSum = 0;
        int start = 0;
        HashSet<int> seen = new HashSet<int>();

        for (int end = 0; end < nums.Length; end++)
        {
            while (seen.Contains(nums[end]))
            {
                seen.Remove(nums[start]);
                currentSum -= nums[start];
                start++;
            }

            seen.Add(nums[end]);
            currentSum += nums[end];
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}