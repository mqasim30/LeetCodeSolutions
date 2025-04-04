namespace LeetCode.MaximumBeautyofanArrayAfterApplyingOperation;
public class Solution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        // Find the minimum and maximum values
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        // Setting for range
        // 100000 is constrains, maximum value in nums + k, since values are in [0, 100000]
        // Since the maximum value in nums[] can be up to 100000 and k can also be as large as 100000
        int max_total = Math.Min(100000, max + k);
        int min_total = Math.Max(0, min - k);
        // Setting frequency array and update later
        int range = max_total - min_total + 1;
        int[] freq = new int[range];

        // Updating frequency array
        for (int i = 0; i < nums.Length; i++)
        {
            int left = Math.Max(min_total, nums[i] - k);
            int right = Math.Min(max_total, nums[i] + k);
            freq[left - min_total]++;

            // Mark the end of range in the frequency array freq[]
            if (right + 1 <= max_total)
            {
                freq[right + 1 - min_total]--;
            }
        }

        int current_beauty = 0;
        int max_beauty = 0;

        // Calculate maximum beauty
        for (int i = 0; i < range; i++)
        {
            current_beauty += freq[i];
            max_beauty = Math.Max(max_beauty, current_beauty);

            // If beauty reaches the length of nums, return
            if (max_beauty == nums.Length)
            {
                return max_beauty;
            }
        }
        // Return result
        return max_beauty;
    }
}