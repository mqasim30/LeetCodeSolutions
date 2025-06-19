namespace LeetCode.PartitionArraySuchThatMaximumDifferenceIsK;

public class Solution
{
    public int PartitionArray(int[] nums, int k)
    {
        Array.Sort(nums);
        int ans = 1;
        int rec = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] - rec > k)
            {
                ans++;
                rec = nums[i];
            }
        }
        return ans;
    }
}