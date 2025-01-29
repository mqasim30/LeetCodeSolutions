namespace LeetCode.RedundantConnection;

public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        int n = edges.Length;
        // Create Undirected Graph
        Dictionary<int, List<int>> g = new();
        for (int i = 1; i <= n; i++)
            g[i] = new();
        foreach (var edge in edges)
        {
            var src = edge[0];
            var dest = edge[1];

            // u -> v
            g[src].Add(dest);
            // v -> u
            g[dest].Add(src);
        }
        // Find Cycle and All Edges in that cycle
        int[] parent = new int[n + 1];
        bool[] visited = new bool[n + 1];
        HashSet<string> edgeIncycle = new();
        DFS(1, -1);

        // Iterate thru n-1...0 in edges first edge which is part of cycle is the ans 
        for (int i = n - 1; i >= 0; i--)
            if (edgeIncycle.Contains(edges[i][0] + "|" + edges[i][1]))
                return edges[i];
        return [-1, -1];

        // local helper func
        bool DFS(int cur, int papa)
        {
            visited[cur] = true;
            parent[cur] = papa;
            foreach (var adj in g[cur])
            {
                if (adj == papa) continue;
                else if (!visited[adj])
                {
                    if (DFS(adj, cur)) return true;
                }
                else // found cycle
                {
                    // add edges in cycle to a grp
                    edgeIncycle.Add(cur + "|" + adj);
                    edgeIncycle.Add(adj + "|" + cur);
                    var elder = cur;
                    while (elder != adj)
                    {
                        elder = parent[cur];
                        edgeIncycle.Add(cur + "|" + elder);
                        edgeIncycle.Add(elder + "|" + cur);
                        cur = elder;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}