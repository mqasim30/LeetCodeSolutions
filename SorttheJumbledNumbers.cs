namespace LeetCode.SorttheJumbledNumbers;

public class Solution
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        List<(int original, int mapped)> mappedNums = new List<(int original, int mapped)>();

        foreach (int num in nums)
        {
            char[] chars = num.ToString().ToCharArray();
            string mapped_value = "";
            for (int i = 0; i < chars.Length; i++)
            {
                mapped_value += mapping[chars[i] - '0'];
            }
            mappedNums.Add((num, Int32.Parse(mapped_value)));
        }

        var sortedNums = mappedNums.OrderBy(pair => pair.mapped).Select(pair => pair.original).ToArray();

        return sortedNums;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] mapping = [8, 9, 4, 0, 2, 1, 3, 5, 7, 6], nums = [991, 338, 38];
//         var answer = solution.SortJumbled(mapping, nums);
//         foreach (var item in answer)
//         {
//             Console.WriteLine("Result = " + item);
//         }
//     }
// }