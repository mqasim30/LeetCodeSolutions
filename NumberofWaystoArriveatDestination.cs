namespace LeetCode.NumberofWaystoArriveatDestination;

public class Solution
{
    public int CountPaths(int n, int[][] roads)
    {

        List<(int node, int time)>[] graph = new List<(int node, int time)>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        foreach (var road in roads)
        {
            graph[road[0]].Add((road[1], road[2]));
            graph[road[1]].Add((road[0], road[2]));
        }

        long[] minTime = new long[n];
        Array.Fill(minTime, Int64.MaxValue);
        int[] ways = new int[n];
        minTime[0] = 0;
        ways[0] = 1;
        int MOD = 1_000_000_007;

        PriorityQueue<int, long> pq = new PriorityQueue<int, long>();
        pq.Enqueue(0, 0);
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int currNode, out long timeTaken);

            foreach (var nei in graph[currNode])
            {
                long time = timeTaken + nei.time;
                if (time < minTime[nei.node])
                {
                    minTime[nei.node] = time;
                    ways[nei.node] = ways[currNode];
                    pq.Enqueue(nei.node, time);
                }
                else if (time == minTime[nei.node])
                {
                    ways[nei.node] = (ways[nei.node] + ways[currNode]) % MOD;
                }
            }
        }

        return ways[n - 1];
    }
}