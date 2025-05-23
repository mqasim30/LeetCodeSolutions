namespace LeetCode.FindtheMaximumSumofNodeValues
{
    public class Solution
    {
        public long MaximumValueSum(int[] nums, int k, int[][] edges)
        {
            long result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result += nums[i];
            }

            int[] deltaNums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                deltaNums[i] = (nums[i] ^ k) - nums[i];
            }

            Array.Sort(deltaNums, (x, y) => y.CompareTo(x));

            for (int i = 0; i < deltaNums.Length; i += 2)
            {
                if (i + 1 > deltaNums.Length - 1)
                {
                    break;
                }

                if (deltaNums[i] + deltaNums[i + 1] > 0)
                {
                    result += deltaNums[i] + deltaNums[i + 1];
                }
            }

            return result;
        }
    }
}