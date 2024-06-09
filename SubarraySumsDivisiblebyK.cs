namespace LeetCode.SubarraySumsDivisiblebyK;

public class Solution
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        int result = 0;
        int sum = 0;
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>(){
            {0,1}
        };

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            Console.WriteLine("Sum: " + sum);
            int remainder = sum % k;
            Console.WriteLine("Remainder: " + remainder);
            if (remainder < 0)
            {
                remainder += k;
            }
            if (keyValuePairs.ContainsKey(remainder))
            {
                result += keyValuePairs[remainder];
                keyValuePairs[remainder] += 1;
            }
            else
            {
                keyValuePairs[remainder] = 1;
            }
        }
        return result;
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [2, -2, 2, -4];
//         int k = 6;
//         Console.WriteLine(solution.SubarraysDivByK(nums, k));
//     }
// }
