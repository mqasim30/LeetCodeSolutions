namespace LeetCode.MaximumWidthRamp;

public class Solution
{
    public int MaxWidthRamp(int[] nums)
    {
        int n = nums.Length;
        int[] rightMax = new int[n];
        rightMax[n - 1] = nums[n - 1];

        // Fill the rightMax array
        for (int i = n - 2; i >= 0; i--)
            rightMax[i] = Math.Max(rightMax[i + 1], nums[i]);

        int left = 0, right = 0, maxVal = 0;

        // Find the maximum width ramp
        while (right < n)
        {
            while (right < n && nums[left] <= rightMax[right])
                right++;

            maxVal = Math.Max(maxVal, right - left - 1);
            left++;
            right = left + maxVal + 1;
        }

        return maxVal;
    }
}