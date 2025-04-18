namespace LeetCode.ContinuousSubarrays;
public class Solution
{
    public long ContinuousSubarrays(int[] nums)
    {

        int left = 0;
        long result = 0;
        // This is array to store indices of minimum and maximum values within the sliding window
        int[] min = new int[nums.Length];
        int[] max = new int[nums.Length];
        int minidx = 0;
        int maxidx = 0;

        // Iterate through the array with the right pointer
        for (int right = 0; right < nums.Length; ++right)
        {
            // Maintain the sliding window for the minimum values
            // Remove elements from the min array where the current element is smaller
            while (minidx > 0 && nums[min[minidx - 1]] >= nums[right])
            {
                minidx--;
            }
            // Maintain the sliding window for the maximum values
            // Remove elements from the 'max' array where the current element is larger
            while (maxidx > 0 && nums[max[maxidx - 1]] <= nums[right])
            {
                maxidx--;
            }

            // I add the current index to both min and max arrays
            min[minidx++] = right;
            max[maxidx++] = right;

            // Ensure that the subarray is valid by checking the condition |max - min| <= 2
            // If the difference between the maximum and minimum values exceeds 2, slide the left
            while (nums[max[0]] - nums[min[0]] > 2)
            {
                left++;

                // If the left pointer passes the minimum element
                // Just remove the minimum value from the min array
                if (min[0] < left)
                {
                    minidx--;

                    for (int i = 0; i < minidx; i++)
                    {
                        min[i] = min[i + 1];
                    }
                }
                // Otherwise
                // Just remove the minimum value from the max array
                if (max[0] < left)
                {
                    maxidx--;

                    for (int i = 0; i < maxidx; i++)
                    {
                        max[i] = max[i + 1];
                    }
                }
            }
            // Add the number of valid subarrays ending at right to the result
            // Subarrays are valid that end at the right index and start anywhere from left to right
            // The subarray must have all values satisfying the condition |max - min| <= 2 so every subarray between left and right is valid
            result += (right - left + 1);
        }
        // Return the total number of valid subarrays
        return result;
    }
}