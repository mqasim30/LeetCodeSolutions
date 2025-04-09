namespace LeetCode.MinimumOperationstoMakeArrayValuesEqualtoK;

public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        HashSet<int> uniqueGreaterThanK = new HashSet<int>();

        foreach (int num in nums)
        {
            if (num < k)
            {
                return -1;
            }
            else if (num > k)
            {
                uniqueGreaterThanK.Add(num);
            }
        }

        return uniqueGreaterThanK.Count;
    }
}