namespace LeetCode.SubarraySumEqualsK;

public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>() { { 0, 1 } };
        int sum = 0, result = 0;
        foreach (var num in nums)
        {
            sum += num;
            if (keyValuePairs.ContainsKey(sum - k))
            {
                result += keyValuePairs[sum - k];
            }
            if (keyValuePairs.ContainsKey(sum))
            {
                keyValuePairs[sum] += 1;
            }
            else
            {
                keyValuePairs[sum] = 1;
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
//         int[] nums = [1, 2, 3];
//         int k = 3;
//         Console.WriteLine("Result = " + solution.SubarraySum(nums, k));
//     }
// }