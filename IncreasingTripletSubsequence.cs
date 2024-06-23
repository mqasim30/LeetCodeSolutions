namespace LeetCode.IncreasingTripletSubsequence;

public class Solution
{
    public bool IncreasingTriplet(int[] nums)
    {
        int min = int.MaxValue;
        int secondMin = int.MaxValue;

        foreach (int num in nums)
        {
            if (num < min)
            {
                min = num;
            }
            else if (num > min && num < secondMin)
            {
                secondMin = num;
            }
            else if (num > secondMin)
            {
                return true;
            }
        }

        return false;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums = [2, 0, 5, 1, 4, 6];
//         Console.WriteLine(solution.IncreasingTriplet(nums));
//     }
// }