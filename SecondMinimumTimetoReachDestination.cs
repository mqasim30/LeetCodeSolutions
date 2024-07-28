namespace LeetCode.SecondMinimumTimetoReachDestination;

public class Solution
{
    public int SecondMinimum(int n, int[][] edges, int time, int change)
    {
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 0; i < n + 1; i++)
        {
            graph[i] = new List<int>();
        }
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        Queue<int[]> queue = new Queue<int[]>();
        int[] visitedNum = new int[n + 1];
        int[] timeArr = new int[n + 1];
        Array.Fill(timeArr, -1);
        queue.Enqueue(new int[] { 1, 0 });
        timeArr[0] = 0;

        while (queue.Count > 0)
        {
            int curSize = queue.Count;
            for (int i = 0; i < curSize; i++)
            {
                var cur = queue.Dequeue();
                int nextTime = 0;
                int curLight = cur[1] / change;
                if (curLight % 2 == 0)
                {
                    nextTime = cur[1] + time;
                }
                else
                {
                    nextTime = (curLight + 1) * change + time;
                }

                foreach (int nextNode in graph[cur[0]])
                {
                    if (visitedNum[nextNode] < 2 && timeArr[nextNode] < nextTime)
                    {
                        queue.Enqueue(new int[] { nextNode, nextTime });
                        visitedNum[nextNode]++;
                        timeArr[nextNode] = nextTime;
                        if (nextNode == n && visitedNum[nextNode] == 2)
                        {
                            return nextTime;
                        }
                    }
                }
            }
        }
        return -1;
    }
}
