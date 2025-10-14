namespace LeetCode.AdjacentIncreasingSubarraysDetectionI;

public class Solution
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        var increasingCount = 1;
        var prevIncreasingCount = 1;
        var start = 1;

        for (int i = start; i < nums.Count; i++)
        {
            if (nums[i] > nums[i - 1])
                increasingCount++;
            else
            {
                prevIncreasingCount = increasingCount;
                increasingCount = 1;
            }

            if (increasingCount / 2 >= k || (increasingCount >= k && prevIncreasingCount >= k))
                return true;
        }
        return false;
    }
}