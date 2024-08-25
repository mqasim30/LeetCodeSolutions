namespace LeetCode.BinaryTreePostorderTraversal;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        return Handle(root).ToList();
    }

    private IEnumerable<int> Handle(TreeNode? root)
    {
        if (root is not null)
        {
            foreach (int item in Handle(root.left))
            {
                yield return item;
            }

            foreach (int item in Handle(root.right))
            {
                yield return item;
            }

            yield return root.val;
        }
    }
}