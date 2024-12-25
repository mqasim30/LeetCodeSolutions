namespace LeetCode.FindMinimumDiameterAfterMergingTwoTrees;

public class Solution
{
    public (int diameter, int depth) TreeDepth(int[][] edges)
    {
        int n = edges.Length + 1;
        var adj = Enumerable.Repeat(0, n).Select(_ => new HashSet<int>()).ToArray();
        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }
        var leafs = new List<int>();
        for (int i = 0; i < n; i++)
            if (adj[i].Count == 1)
                leafs.Add(i);
        int left = n;
        int depth = 0;
        while (left > 2)
        {
            left -= leafs.Count;
            var nextLeafs = new List<int>();
            foreach (var leaf in leafs)
            {
                int parent = adj[leaf].First();
                adj[parent].Remove(leaf);
                if (adj[parent].Count == 1)
                    nextLeafs.Add(parent);
            }
            leafs = nextLeafs;
            depth++;
        }
        if (left == 2)
            return (2 * depth + 1, depth + 1);
        return (2 * depth, depth);
    }
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        var tree1 = TreeDepth(edges1);
        var tree2 = TreeDepth(edges2);
        int res = Math.Max(tree1.diameter, tree2.diameter);
        res = Math.Max(res, tree1.depth + 1 + tree2.depth);
        return res;
    }
}