namespace LeetCode.ThreeConsecutiveOdds;

public class Solution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        if (arr.Length < 3)
        {
            return false;
        }
        
        for (int i = 0; i < arr.Length - 2; i++)
        {
            if (arr[i] % 2 == 1 && arr[i + 1] % 2 == 1 && arr[i + 2] % 2 == 1)
            {
                return true;
            }
        }
        
        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] arr = [1, 2, 34, 3, 4, 5, 7, 23, 12];
        Console.WriteLine(solution.ThreeConsecutiveOdds(arr));

    }
}