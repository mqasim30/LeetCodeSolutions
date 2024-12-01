namespace LeetCode.CheckIfNandItsDoubleExist;
public class Solution
{
    public bool CheckIfExist(int[] arr)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in arr)
        {
            if (seen.Contains(2 * num) || (num % 2 == 0 && seen.Contains(num / 2)))
            {
                return true;
            }
            seen.Add(num);
        }

        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new();
        //int[] arr = [10, 2, 5, 3];
        //int[] arr = [3, 1, 7, 11];
        //int[] arr = [7, 1, 14, 11];
        int[] arr = [0, 0];
        Console.WriteLine(solution.CheckIfExist(arr));
    }
}