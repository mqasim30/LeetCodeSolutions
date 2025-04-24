namespace LeetCode.CountCompleteSubarraysinanArray;
public class Solution
{
    public int CountCompleteSubarrays(int[] nums)
    {
        int y = nums.Distinct().Count();
        int count = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            HashSet<int> st = new HashSet<int>();
            for (int j = i; j < n; j++)
            {
                st.Add(nums[j]);
                if (st.Count == y)
                {
                    count++;
                }
            }
        }
        return count;
    }
}