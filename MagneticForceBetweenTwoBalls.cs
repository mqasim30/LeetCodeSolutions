namespace LeetCode.MagneticForceBetweenTwoBalls;

public class Solution
{
    public int MaxDistance(int[] position, int m)
    {
        int result = 0;
        Array.Sort(position);

        int low = 1;
        int high = (position[position.Length - 1] - position[0]) / (m - 1);

        Console.WriteLine(high);

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            Console.WriteLine("Mid: " + mid);
            if (CanPlace(position, mid, m))
            {
                result = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return result;
    }
    private bool CanPlace(int[] arr, int dist, int m)
    {
        int cntM = 1;
        int last = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] - last >= dist)
            {
                cntM++;
                last = arr[i];
            }
            if (cntM >= m)
            {
                return true;
            }
        }
        return false;
    }
}
// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] position = [1, 2, 3, 4, 7];
//         int m = 3;
//         Console.WriteLine(solution.MaxDistance(position, m));
//     }
// }
