namespace LeetCode.CheckIfAll1sAreatLeastLengthKPlacesAway;

public class Solution
{
    public bool KLengthApart(int[] nums, int k)
    {
        if (k == 0) return true;

        var lastIndex = -k - 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) continue;
            if (i - lastIndex <= k) return false;

            lastIndex = i;
        }

        return true;
    }
}