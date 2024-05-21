namespace LeetCode.TopKFrequentElements
{
    public class Solution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (keyValuePairs.ContainsKey(num))
                {
                    keyValuePairs[num] += 1;
                    continue;
                }
                keyValuePairs.Add(num, 1);
            }

            int[] result = new int[k];

            result = keyValuePairs
                .OrderByDescending(pair => pair.Value)
                .Take(k)
                .Select(pair => pair.Key)
                .ToArray();

            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] ints = [3, 0, 1, 0];
    //         foreach (var item in solution.TopKFrequent(ints, 1))
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    // }
}