namespace LeetCode.RangeSumofSortedSubarraySums;

public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        List<int> subarraySums = new List<int>();
        for (int i = 0; i < n; ++i) {
            int sum = 0;
            for (int j = i; j < n; ++j) {
                sum += nums[j];
                subarraySums.Add(sum);
            }
        }

        subarraySums.Sort();

        int ans = 0;
        const int mod = 1000000007;
        for (int i = left - 1; i < right; ++i) {
            ans = (ans + subarraySums[i]) % mod;
        }

        return ans;
    }
}
