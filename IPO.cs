namespace LeetCode.IPO;

public class Solution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length;
        List<(int,int)> projects = new List<(int,int)>();

        // Creating list of projects with capital and profits
        for (int i = 0; i < n; i++)
        {
            projects.Add(new (capital[i], profits[i]));
        }

        // Sorting projects by capital required
        projects.Sort((a, b) => a.Item1 - b.Item2);

        // Max-heap to store profits
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        int currentIndex = 0;

        // Main loop to select up to k projects
        for (int j = 0; j < k; j++)
        {
            // Add all profitable projects that we can afford
            while (currentIndex < n && projects[currentIndex].Item1 <= w)
            {
                maxHeap.Enqueue(projects[currentIndex].Item2, projects[currentIndex].Item2);
                currentIndex++;
            }

            // If no projects can be funded, break out of the loop
            if (maxHeap.Count == 0)
            {
                break;
            }

            // Otherwise, take the project with the maximum profit
            w += maxHeap.Dequeue();
        }

        return w;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int k = 2, w = 0;
        int[] profits = { 1, 2, 3 };
        int[] capital = { 0, 1, 1 };
        Console.WriteLine(solution.FindMaximizedCapital(k, w, profits, capital));  // Output should be 4
    }
}
