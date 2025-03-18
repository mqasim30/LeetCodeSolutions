namespace LeetCode.DivideArrayIntoEqualPairs;

public class Solution
{
    public bool DivideArray(int[] nums)
    {
        if (nums.Length % 2 != 0)
            return false;

        HashSet<int> unlinkedPairs = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (unlinkedPairs.Add(nums[i]) == false)
                unlinkedPairs.Remove(nums[i]);
        }

        if (unlinkedPairs.Count > 0)
            return false;
        return true;
    }
}