namespace LeetCode.SpecialArrayI;

public class Solution
{
    public bool IsArraySpecial(int[] nums)
    {
        bool prev = (nums[0] % 2 == 0);
        for (int i = 1; i < nums.Length; i++)
        {
            bool curr = (nums[i] % 2 == 0);
            if (curr == prev)
                return false;
            prev = curr;
        }
        return true;
    }
}