namespace LeetCode.SortColors;

public class Solution
{
    public void SortColors(int[] nums)
    {
        int zeroCount = 0;
        int oneCount = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroCount += 1;
            }
            else if (nums[i] == 1)
            {
                oneCount += 1;
            }
        }

        for (int i = 0; i < zeroCount; i++)
        {
            nums[i] = 0;
        }

        for (int i = zeroCount; i < oneCount + zeroCount; i++)
        {
            nums[i] = 1;
        }

        for (int i = oneCount + zeroCount; i < nums.Length; i++)
        {
            nums[i] = 2;
        }
    }
}