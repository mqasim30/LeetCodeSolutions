namespace LeetCode.CountNumberofBadPairs;

public class Solution
{
    public long CountBadPairs(int[] nums)
    {
        long count = 0;
        Dictionary<int, int> freq = new(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            int n = i - nums[i];
            int matches = freq[n] = freq.GetValueOrDefault(n) + 1;
            count += i - matches + 1;
        }
        return count;
    }
}