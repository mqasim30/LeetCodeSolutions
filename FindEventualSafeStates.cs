namespace LeetCode.FindEventualSafeStates;

public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n = graph.Length;
        int[] color = new int[n];

        IList<int> result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (DFS(graph, color, i))
            {
                result.Add(i);
            }
        }

        return result;
    }

    private bool DFS(int[][] graph, int[] color, int node)
    {
        if (color[node] > 0)
        {
            return color[node] == 2;
        }

        color[node] = 1;

        foreach (int next in graph[node])
        {
            if (color[next] == 2)
            {
                continue;
            }

            if (color[next] == 1 || !DFS(graph, color, next))
            {
                return false;
            }
        }

        color[node] = 2;

        return true;
    }
}