namespace LeetCode.ContinuousSubarraySum;

public class Solution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> myDictionary = new Dictionary<int, int>
        {
            { 0, -1 }
        };
        int total = 0;

        for (int index = 0; index < nums.Length; index++)
        {
            total += nums[index];
            int remainder = total % k;
            if (!myDictionary.ContainsKey(remainder))
            {
                myDictionary.Add(remainder, index);
            }
            else if ((index - myDictionary[remainder]) >= 2)
            {
                return true;
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
//     }
// }
