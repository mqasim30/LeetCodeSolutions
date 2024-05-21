namespace LeetCode.SingleNumber
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                result = result ^ num;
            }
            Console.WriteLine(result);
            return result;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         solution.SingleNumber([4,1,2,1,2]);
    //     }
    // }
}