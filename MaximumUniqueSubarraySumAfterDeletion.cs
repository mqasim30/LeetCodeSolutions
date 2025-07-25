namespace LeetCode.MaximumUniqueSubarraySumAfterDeletion;

public class Solution
{
    public int MaxSum(int[] nums)
    {
        HashSet<int> positiveNumsSet = new HashSet<int>();
        foreach (int num in nums)
        {
            if (num > 0)
            {
                positiveNumsSet.Add(num);
            }
        }
        if (positiveNumsSet.Count == 0)
        {
            return nums.Max();
        }
        return positiveNumsSet.Sum();
    }
}