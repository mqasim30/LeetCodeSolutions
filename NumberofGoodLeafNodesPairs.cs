namespace LeetCode.NumberofGoodLeafNodesPairs;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution
{
    public int CountPairs(TreeNode root, int distance)
    {
        var map = new Dictionary<TreeNode, List<TreeNode>>();
        var leaves = new List<TreeNode>();
        FindLeaves(root, new List<TreeNode>(), leaves, map);
        int res = 0;
        for (int i = 0; i < leaves.Count; i++)
        {
            for (int j = i + 1; j < leaves.Count; j++)
            {
                var list_i = map[leaves[i]];
                var list_j = map[leaves[j]];
                for (int k = 0; k < Math.Min(list_i.Count, list_j.Count); k++)
                {
                    if (list_i[k] != list_j[k])
                    {
                        int dist = list_i.Count - k + list_j.Count - k;
                        if (dist <= distance) res++;
                        break;
                    }
                }
            }
        }
        return res;
    }

    private void FindLeaves(TreeNode node, List<TreeNode> trail, List<TreeNode> leaves, Dictionary<TreeNode, List<TreeNode>> map)
    {
        if (node == null) return;
        var tmp = new List<TreeNode>(trail) { node };
        if (node.left == null && node.right == null)
        {
            map[node] = tmp;
            leaves.Add(node);
            return;
        }
#pragma warning disable CS8604 // Possible null reference argument.
        FindLeaves(node.left, tmp, leaves, map);
#pragma warning restore CS8604 // Possible null reference argument.
        FindLeaves(node.right, tmp, leaves, map);
    }
}
