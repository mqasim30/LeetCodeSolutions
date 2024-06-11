namespace LeetCode.HeightChecker;

public class Solution
{
    public int HeightChecker(int[] heights)
    {
        int result = 0;
        int[] sortedHeights = (int[])heights.Clone();
        Array.Sort(sortedHeights);
        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != sortedHeights[i])
            {
                result += 1;
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
//         int[] heights = [1, 1, 4, 2, 1, 3];
//         Console.WriteLine(solution.HeightChecker(heights));
//     }
// }
