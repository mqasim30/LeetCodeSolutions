namespace LeetCode.RemoveElement
{

    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int left = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[left] = nums[i];
                    left++;                
                }
            }
            return left;
        }
    }
    
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [3,2,2,3];
    //         solution.RemoveElement(nums, 3);
    //     }
    // }
}