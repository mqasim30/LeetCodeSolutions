namespace LeetCode.MinimumArrayChangestoMakeDifferencesEqual;

public class Solution {
    public int MinChanges(int[] nums, int k) {
        Dictionary<int, int> s = new Dictionary<int, int>();
        int n = nums.Length;
        int[] f = new int[k + 1];
        
        for (int i = 0; i < n / 2; i++) {
            int diff = Math.Abs(nums[i] - nums[n - 1 - i]);
            if (s.ContainsKey(diff)) {
                s[diff]++;
            } else {
                s[diff] = 1;
            }
            
            int min = Math.Min(nums[i], nums[n - 1 - i]);
            int max = Math.Max(nums[i], nums[n - 1 - i]);
            f[Math.Max(k - min, max)]++;
        }
        
        for (int i = k - 1; i >= 0; i--) {
            f[i] += f[i + 1];
        }
        
        int ans = n;
        
        foreach (int x in s.Keys) {
            int one = f[x] - s[x];
            int two = n / 2 - f[x];
            ans = Math.Min(ans, one + two * 2);
        }
        
        return ans;
    }
}
