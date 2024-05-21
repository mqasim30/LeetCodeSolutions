namespace LeetCode.TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numbers.ContainsKey(complement))
                {
                    return new int[] { i, numbers[complement] };
                }
                if (!numbers.ContainsKey(nums[i]))
                {
                    numbers[nums[i]] = i;
                }
            }
            return new int[] { 0, 0 };
        }

        // public static void Main(string[] args)
        // {
        //     Solution solution = new Solution();
        //     int[] nums = [1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1];
        //     int target = 11;
        //     int[] answer = solution.TwoSum(nums, target);
        //     Console.WriteLine(answer[0].ToString());
        //     Console.WriteLine(answer[1].ToString());
        // }
    }


}
