namespace LeetCode.IPO;

public class Solution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length;
        List<(int,int)> projects = new List<(int,int)>();

        for (int i = 0; i < n; i++)
        {
            projects.Add(new (capital[i], profits[i]));
        }

        projects.Sort((a, b) => a.Item1 - b.Item2);

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        int currentIndex = 0;

        for (int j = 0; j < k; j++)
        {
            while (currentIndex < n && projects[currentIndex].Item1 <= w)
            {
                maxHeap.Enqueue(projects[currentIndex].Item2, projects[currentIndex].Item2);
                currentIndex++;
            }

            if (maxHeap.Count == 0)
            {
                break;
            }

            w += maxHeap.Dequeue();
        }

        return w;
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int k = 2, w = 0;
//         int[] profits = { 1, 2, 3 };
//         int[] capital = { 0, 1, 1 };
//         Console.WriteLine(solution.FindMaximizedCapital(k, w, profits, capital));
//     }
// }
