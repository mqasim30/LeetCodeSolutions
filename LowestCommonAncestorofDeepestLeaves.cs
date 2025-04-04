namespace LeetCode.LowestCommonAncestorofDeepestLeaves;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
public class Solution
{
    private class Result
    {
        public TreeNode Node;
        public int Depth;

        public Result(TreeNode node, int depth)
        {
            Node = node;
            Depth = depth;
        }
    }
    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        return Dfs(root).Node;
    }
    private Result Dfs(TreeNode root)
    {
        if (root == null)
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return new Result(null, 0);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        Result left = Dfs(root.left);
        Result right = Dfs(root.right);

        if (left.Depth == right.Depth)
        {
            return new Result(root, left.Depth + 1);
        }
        else if (left.Depth > right.Depth)
        {
            return new Result(left.Node, left.Depth + 1);
        }
        else
        {
            return new Result(right.Node, right.Depth + 1);
        }
    }
}