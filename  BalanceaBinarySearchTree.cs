namespace LeetCode.BalanceaBinarySearchTree;

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
    public TreeNode BalanceBST(TreeNode root)
    {
        List<int> sortedElements = new List<int>();
        InOrderTraversal(root, sortedElements);
        return BuildBalancedBST(sortedElements, 0, sortedElements.Count - 1);
    }

    private void InOrderTraversal(TreeNode node, List<int> sortedElements)
    {
        if (node == null)
        {
            return;
        }
        InOrderTraversal(node.left, sortedElements);
        sortedElements.Add(node.val);
        InOrderTraversal(node.right, sortedElements);
    }

    private TreeNode BuildBalancedBST(List<int> elements, int start, int end)
    {
        if (start > end)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }
        int mid = start + (end - start) / 2;
        TreeNode node = new TreeNode(elements[mid]);
        node.left = BuildBalancedBST(elements, start, mid - 1);
        node.right = BuildBalancedBST(elements, mid + 1, end);
        return node;
    }
}