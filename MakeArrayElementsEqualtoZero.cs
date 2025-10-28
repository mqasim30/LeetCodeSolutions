namespace LeetCode.MakeArrayElementsEqualtoZero;
public class Solution
{
    public int CountValidSelections(int[] nums)
    {
        int n = nums.Length;
        int validCount = 0;

        for (int start = 0; start < n; start++)
        {
            if (nums[start] == 0)
            {
                if (IsValid(nums, start, 1)) validCount++;
                if (IsValid(nums, start, -1)) validCount++;
            }
        }

        return validCount;
    }
    private bool IsValid(int[] nums, int start, int dir)
    {
        int n = nums.Length;
        int[] arr = (int[])nums.Clone();
        int curr = start;

        while (curr >= 0 && curr < n)
        {
            if (arr[curr] == 0)
            {
                curr += dir;
            }
            else
            {
                arr[curr]--;
                dir = -dir;
                curr += dir;
            }
        }

        foreach (int x in arr)
        {
            if (x != 0) return false;
        }

        return true;
    }
}