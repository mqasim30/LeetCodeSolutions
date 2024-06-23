namespace LeetCode.CanPlaceFlowers;

public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (n == 0)
            {
                return true;
            }
            if (flowerbed[i] == 0)
            {
                if ((i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    n -= 1;
                }
            }
            else
            {
                i++;
            }
        }
        return n == 0;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] flowerbed = [1, 0, 0, 0, 0, 1];
//         int n = 2;
//         System.Console.WriteLine(solution.CanPlaceFlowers(flowerbed, n));
//     }
// }