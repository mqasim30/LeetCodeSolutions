namespace LeetCode.ShortestSubarrayWithORatLeastKII;

public class Solution
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        int minLength = int.MaxValue;
        int windowStart = 0;
        int windowEnd = 0;
        int[] bitCounts = new int[32]; // Tracks count of set bits at each position

        // Expand window until end of array
        while (windowEnd < nums.Length)
        {
            // Add current number to window
            UpdateBitCounts(bitCounts, nums[windowEnd], 1);

            // Contract window while OR value is valid
            while (windowStart <= windowEnd && ConvertBitCountsToNumber(bitCounts) >= k)
            {
                // Update minimum length found so far
                minLength = Math.Min(minLength, windowEnd - windowStart + 1);

                // Remove leftmost number and shrink window
                UpdateBitCounts(bitCounts, nums[windowStart], -1);
                windowStart++;
            }

            windowEnd++;
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }

    // Updates bit count array when adding/removing a number from window
    private void UpdateBitCounts(int[] bitCounts, int number, int delta)
    {
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            // Check if bit is set at current position
            if (((number >> bitPosition) & 1) != 0)
            {
                bitCounts[bitPosition] += delta;
            }
        }
    }

    // Converts bit count array back to number using OR operation
    private int ConvertBitCountsToNumber(int[] bitCounts)
    {
        int result = 0;
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            if (bitCounts[bitPosition] != 0)
            {
                result |= 1 << bitPosition;
            }
        }
        return result;
    }
}