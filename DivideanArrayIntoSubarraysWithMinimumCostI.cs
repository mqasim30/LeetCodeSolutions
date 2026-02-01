namespace LeetCode.DivideanArrayIntoSubarraysWithMinimumCostI;


public class Solution
{
    public int MinimumCost(int[] nums)
    {
        if (nums.Length == 3)
            return nums.Sum();
        int ans = nums[0];
        List<int> ls = nums.ToList();
        ls.RemoveAt(0);
        ans += ls.Min();
        ls.Remove(ls.Min());
        ans += ls.Min();
        return ans;
    }
}