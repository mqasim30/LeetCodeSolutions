namespace LeetCode.ContainerWithMostWater;
public class Solution
{
    public int MaxArea(int[] height)
    {
        int result = 0, left = 0, right = height.Length - 1;

        while (left < right)
        {
            int area = (right - left) * Math.Min(height[left], height[right]);
            result = Math.Max(result, area);
            if (height[left] < height[right])
            {
                left++;
                while ((left < right) && (height[left] <= height[left - 1]))
                {
                    left++;
                }
            }
            else
            {
                right--;
                while ((left < right) && (height[right] <= height[right + 1]))
                {
                    right--;
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
//         int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
//         Console.WriteLine(solution.MaxArea(height));
//     }
// }
