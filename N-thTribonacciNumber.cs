namespace LeetCode.NthTribonacciNumber
{
    public class Solution
    {
        public int Tribonacci(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return TribonacciHelper(n, memo);
        }

        private int TribonacciHelper(int n, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                int result = TribonacciHelper(n - 1, memo) + TribonacciHelper(n - 2, memo) + TribonacciHelper(n - 3, memo);
                memo[n] = result;
                return result;
            }
        }
    }
}