namespace LeetCode.BestTimetoBuyandSellStock
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int left = 0, right = 1;
            while (left < prices.Length && right < prices.Length)
            {
                if (prices[left] > prices[right])
                {
                    left = right;
                    right++;
                    continue;
                }
                else
                {
                    Console.WriteLine($"Found profit at index {left} , {right}");
                    if (profit < (prices[right] - prices[left]))
                    {
                        profit = prices[right] - prices[left];
                    }
                    right++;
                }
            }
            Console.WriteLine(profit);
            return profit;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] prices = [2,1,2,1,0,1,2];
    //         solution.MaxProfit(prices);
    //     }
    // }
}