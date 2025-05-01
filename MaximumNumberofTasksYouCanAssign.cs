namespace LeetCode.MaximumNumberofTasksYouCanAssign;

public class Solution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        int n = tasks.Length, m = workers.Length;
        Array.Sort(tasks);
        Array.Sort(workers);

        Func<int, bool> check = mid =>
        {
            int p = pills;
            var ws = new LinkedList<int>();
            int ptr = m - 1;
            // Enumerate each task from largest to smallest
            for (int i = mid - 1; i >= 0; --i)
            {
                while (ptr >= m - mid && workers[ptr] + strength >= tasks[i])
                {
                    ws.AddFirst(workers[ptr]);
                    --ptr;
                }
                if (ws.Count == 0)
                {
                    return false;
                }
                else if (ws.Last.Value >= tasks[i])
                {
                    // If the largest element in the deque is greater than or
                    // equal to tasks[i]
                    ws.RemoveLast();
                }
                else
                {
                    if (p == 0)
                    {
                        return false;
                    }
                    --p;
                    ws.RemoveFirst();
                }
            }
            return true;
        };

        int left = 1, right = Math.Min(m, n), ans = 0;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (check(mid))
            {
                ans = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return ans;
    }
}