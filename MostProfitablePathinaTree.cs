namespace LeetCode.MostProfitablePathinaTree;
public class Solution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var adjList = new Dictionary<int, List<int>>();
        int res = int.MinValue;
        foreach (var edge in edges)
        {
            if (!adjList.ContainsKey(edge[0]))
                adjList[edge[0]] = new List<int>();
            if (!adjList.ContainsKey(edge[1]))
                adjList[edge[1]] = new List<int>();

            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        var bobReachTime = new Dictionary<int, int>();
        DFS(bob, -1, 0);
        bool DFS(int node, int prev, int time)
        {
            if (node == 0)
            {
                bobReachTime[node] = time;
                return true;
            }
            foreach (var nei in adjList[node])
            {
                if (nei == prev)
                    continue;
                if (DFS(nei, node, time + 1))
                {
                    bobReachTime[node] = time;
                    return true;
                }
            }
            return false;
        }

        var queue = new Queue<(int, int, int, int)>();
        queue.Enqueue((0, -1, 0, amount[0]));
        while (queue.Count > 0)
        {
            var (node, prev, time, total) = queue.Dequeue();
            foreach (var nei in adjList[node])
            {
                if (nei == prev)
                    continue;
                else
                {
                    var nei_time = time + 1;
                    var nei_total = amount[nei];

                    if (bobReachTime.ContainsKey(nei) && bobReachTime[nei] < nei_time)
                        nei_total = 0;
                    else if (bobReachTime.ContainsKey(nei) && bobReachTime[nei] == nei_time)
                        nei_total = (amount[nei] / 2);
                    queue.Enqueue((nei, node, nei_time, total + nei_total));
                    if (adjList[nei].Count == 1)
                        res = Math.Max(res, total + nei_total);
                }
            }
        }


        return res;
    }
}