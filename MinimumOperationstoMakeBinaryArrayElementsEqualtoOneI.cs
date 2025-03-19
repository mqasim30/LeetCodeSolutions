namespace LeetCode.MinimumOperationstoMakeBinaryArrayElementsEqualtoOneI;

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] == 0)
            {
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                result++;
            }
        }

        if (nums.Contains(0))
        {
            return -1;
        }
        else
            return result;
    }
}