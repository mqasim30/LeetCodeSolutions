namespace LeetCode.SumofAllSubsetXORTotals;
public class Solution
{
    private int DFS(int i, int result, int length, int[] nums)
    {
        if (i == length)
        {
            return result;
        }
        return DFS(i + 1, result ^ nums[i], length, nums) + DFS(i + 1, result, length, nums);
    }
    public int SubsetXORSum(int[] nums)
    {
        return DFS(0, 0, nums.Length, nums);
    }
}
