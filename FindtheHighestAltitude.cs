namespace LeetCode.FindtheHighestAltitude;

public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        int result = 0;
        int sum = 0;
        foreach (var num in gain)
        {
            sum += num;
            if (result < sum)
            {
                result = sum;
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
//         int[] gain = [-5, 1, 5, 0, -7];
//         Console.WriteLine("Result = " + solution.LargestAltitude(gain));
//     }
// }