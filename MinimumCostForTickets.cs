namespace LeetCode.MinimumCostForTickets
{
    public class Solution
    {
        public int MincostTickets(int[] days, int[] costs)
        {
            // Initialize the DP array
            int[] dp = new int[days[^1] + 1];
            dp[0] = 0; // Base case: no cost to travel on day 0

            // Fill the DP array
            int dayIndex = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                if (i != days[dayIndex])
                {
                    dp[i] = dp[i - 1];
                }
                else
                {   
                    dp[i] = Math.Min(
                        dp[Math.Max(0, i - 1)] + costs[0],
                        Math.Min(
                            dp[Math.Max(0, i - 7)] + costs[1],
                            dp[Math.Max(0, i - 30)] + costs[2]
                        )
                    );
                    dayIndex++;
                }
            }

            return dp[^1];
        }
    }
}