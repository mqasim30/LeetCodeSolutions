namespace LeetCode.LongestConsecutiveSequence
{
    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> uniqueNums = new HashSet<int>(nums);
            int longestSequenceLength = 0;
            foreach (int num in uniqueNums)
            {
                int prefixNumber = num - 1;
                int postfixNumber = num + 1;

                if (!uniqueNums.Contains(prefixNumber))
                {
                    int length = 0;
                    while (uniqueNums.Contains(num + length))
                    {
                        length += 1;
                    }

                    longestSequenceLength = Math.Max(length, longestSequenceLength);
                }
            }
            return longestSequenceLength;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums = [0,3,7,2,5,8,4,6,0,1];
    //         solution.LongestConsecutive(nums);

    //     }
    // }
}