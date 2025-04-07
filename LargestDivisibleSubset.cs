namespace LeetCode.LargestDivisibleSubset;

public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {

        Array.Sort(nums);
        int n = nums.Length;
        int maxIndex = 0;
        int[] DP = new int[n];
        int[] prev = new int[n];
        Array.Fill(DP, 1);
        Array.Fill(prev, -1);

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && DP[i] < DP[j] + 1)
                {
                    DP[i] = DP[j] + 1;
                    prev[i] = j;
                }
            }
            if (DP[i] > DP[maxIndex])
            {
                maxIndex = i;
            }
        }
        List<int> result = new List<int>() { };
        while (maxIndex != -1)
        {
            result.Add(nums[maxIndex]);
            maxIndex = prev[maxIndex];
        }
        return result;
    }
}