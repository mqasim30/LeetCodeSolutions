namespace LeetCode.MinimumNumberofOperationstoMakeElementsinArrayDistinct;

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        HashSet<int> cache = new();
        int n = nums.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            if (!cache.Contains(nums[i]))
                cache.Add(nums[i]);
            else return i / 3 + 1;
        }
        return 0;
    }
}