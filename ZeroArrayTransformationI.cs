namespace LeetCode.ZeroArrayTransformationI;

public class Solution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        int[] deltaArray = new int[nums.Length + 1];
        foreach (int[] query in queries)
        {
            int left = query[0];
            int right = query[1];
            deltaArray[left] += 1;
            deltaArray[right + 1] -= 1;
        }
        int[] operationCounts = new int[deltaArray.Length];
        int currentOperations = 0;
        for (int i = 0; i < deltaArray.Length; i++)
        {
            currentOperations += deltaArray[i];
            operationCounts[i] = currentOperations;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (operationCounts[i] < nums[i])
            {
                return false;
            }
        }
        return true;
    }
}