namespace LeetCode.FlipEquivalentBinaryTrees;

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
    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null) return true;
        if (root1 == null || root2 == null || root1.val != root2.val) return false;
        bool noFlip = FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right);
        bool flip = FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left);
        return noFlip || flip;
    }
}