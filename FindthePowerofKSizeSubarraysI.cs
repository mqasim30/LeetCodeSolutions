namespace LeetCode.FindthePowerofKSizeSubarraysI;

public class Solution
{
    public int[] ResultsArray(int[] nums, int k)
    {
        var res = new List<int>();
        int l = 0;
        int consecCnt = 1;

        for (int r = 0; r < nums.Length; r++)
        {
            if (r > 0 && nums[r - 1] + 1 == nums[r])
            {
                consecCnt++;
            }

            if (r - l + 1 > k)
            {
                if (nums[l] + 1 == nums[l + 1])
                {
                    consecCnt--;
                }
                l++;
            }

            if (r - l + 1 == k)
            {
                res.Add(consecCnt == k ? nums[r] : -1);
            }
        }

        return res.ToArray();
    }
}