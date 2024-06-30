namespace LeetCode.AllAncestorsofaNodeinaDirectedAcyclicGraph;

public class Solution
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        List<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < n; i++)
        {
            res.Add(new List<int>());
        }

        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }
        foreach (int[] edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
        }

        for (int i = 0; i < n; i++)
        {
            Dfs(graph, i, i, res, new bool[n]);
        }

        for (int i = 0; i < n; i++)
        {
            List<int> ancestors = (List<int>)res[i];
            ancestors.Sort();
        }

        return res;
    }

    private void Dfs(List<int>[] graph, int parent, int curr, IList<IList<int>> res, bool[] visit)
    {
        visit[curr] = true;
        foreach (int dest in graph[curr])
        {
            if (!visit[dest])
            {
                res[dest].Add(parent);
                Dfs(graph, parent, dest, res, visit);
            }
        }
    }
}
