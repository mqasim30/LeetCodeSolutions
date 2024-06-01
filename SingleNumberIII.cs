namespace LeetCode.SingleNumberIII
{
    public class Solution
    {
        public int[] SingleNumber(int[] nums)
        {
            int xorResult = 0;
            foreach (int num in nums)
            {
                xorResult ^= num;
            }

            int diffBit = xorResult & -xorResult;

            int[] result = new int[2];
            foreach (int num in nums)
            {
                if ((num & diffBit) == 0)
                {
                    result[0] ^= num;
                }
                else
                {
                    result[1] ^= num;
                }
            }

            return result;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [1, 2, 1, 3, 2, 5];
    //         solution.SingleNumber(nums);
    //     }
    // }
}