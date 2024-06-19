namespace LeetCode.MostProfitAssigningWork;

public class Solution
{
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        Array.Sort(worker);
        Array.Sort(difficulty, profit);

        int i = 0, j = 0;
        int result = 0;
        int max = 0;

        while (j < worker.Length)
        {
            if (i < difficulty.Length && worker[j] >= difficulty[i])
            {
                max = Math.Max(max, profit[i]);
                i += 1;
            }
            else
            {
                result += max;
                j += 1;
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
//         //int[] difficulty = [85, 47, 57], profit = [24, 66, 99], worker = [40, 25, 25];
//         //int[] difficulty = [2, 4, 6, 8, 10], profit = [10, 20, 30, 40, 50], worker = [4, 5, 6, 7];
//         int[] difficulty = [68, 35, 52, 47, 86], profit = [67, 17, 1, 81, 3], worker = [92, 10, 85, 84, 82];
//         //int[] difficulty = [13, 37, 58], profit = [4, 90, 96], worker = [34, 73, 45];
//         Console.WriteLine(solution.MaxProfitAssignment(difficulty, profit, worker));
//     }
// }

