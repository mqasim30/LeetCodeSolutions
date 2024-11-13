namespace LeetCode.CounttheNumberofFairPairs;

public class Solution
{
    public long CountFairPairs(int[] nums, long lower, long upper)
    {
        Array.Sort(nums);
        long ans = 0;
        int bs(long n, bool low)
        {
            int le = 0;
            int ri = nums.Length - 1;
            while (le <= ri)
            {
                int mid = (ri - le) / 2 + le;
                if (nums[mid] <= n)
                {
                    if (low && nums[mid] == n)
                        ri = mid - 1;
                    else le = mid + 1;
                }
                else ri = mid - 1;
            }
            return le - 1;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            int left = bs(lower - nums[i], true);
            int right = bs(upper - nums[i], false);
            if (left <= i)
            {
                left = i + 1;
                if (left >= nums.Length) continue;
            }
            else if (nums[left] + nums[i] < lower)
            {
                if (left + 1 >= nums.Length || nums[left + 1] + nums[i] < lower) continue;
                left++;
            }
            if (left > right) continue;
            int mid = right - left + 1;
            ans += mid;
        }
        return ans;
    }
}