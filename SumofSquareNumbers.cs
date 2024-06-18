namespace LeetCode.SumofSquareNumbers;

public class Solution
{
    public bool JudgeSquareSum(int c)
    {
        long left = 0;
        long right = (long)Math.Sqrt(c);
        while (left <= right)
        {
            if (left * left + right * right == c)
            {
                return true;
            }
            else if (left * left + right * right > c)
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return false;
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int c = 5;
//         Console.WriteLine(solution.JudgeSquareSum(c));
//     }
// }





