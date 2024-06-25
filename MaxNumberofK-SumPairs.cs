namespace LeetCode.MaxNumberofKSumPairs;
public class Solution
{
    public int MaxOperations(int[] nums, int k)
    {
        int result = 0;
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = k - nums[i];
            if (keyValuePairs.ContainsKey(complement) && keyValuePairs[complement] > 0)
            {
                result += 1;
                keyValuePairs[complement] -= 1;
            }
            else
            {
                if (keyValuePairs.ContainsKey(nums[i]))
                {
                    keyValuePairs[nums[i]] += 1;
                }
                else
                {
                    keyValuePairs.Add(nums[i], 1);
                }
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
//         int[] nums = [3, 1, 3, 4, 3];
//         int k = 6;
//         Console.WriteLine(solution.MaxOperations(nums, k));
//     }
// }
