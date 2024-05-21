using System.Runtime.Versioning;

namespace LeetCode.ProductofArrayExceptSelf
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int prefix = 1, postfix = 1;
            int[] output = new int[nums.Length];
            output[0] = 1;
            
            for (int i = 0; i < nums.Length-1; i++)
            {
                prefix *= nums[i];
                output[i+1] = prefix;
            }

            for(int i = nums.Length -1; i > 0 ; i--)
            {
                postfix *= nums[i];
                output[i-1] = output[i-1] * postfix;
            }
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
            return output;

        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [-1,1,0,-3,3];
    //         solution.ProductExceptSelf(nums);
    //     }
    // }
}