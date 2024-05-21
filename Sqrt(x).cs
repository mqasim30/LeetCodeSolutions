namespace LeetCode.Sqrtx
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }
            long left = 1;
            long right = x;

            while (left <= right)
            {
                long middle = (left + right) / 2;
                long square = middle * middle;

                if (square == x)
                {
                    return (int)middle;
                }
                else if (square < x)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return (int)right;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         Console.WriteLine(solution.MySqrt(2147395599));
    //     }
    // }
}