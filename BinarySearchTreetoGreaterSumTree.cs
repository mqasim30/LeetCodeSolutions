namespace LeetCode.BinarySearchTreetoGreaterSumTree;
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
    int currSum = 0;

    public TreeNode BstToGst(TreeNode root)
    {
        DFS(root);
        return root;
    }

    private void DFS(TreeNode treeNode)
    {
        if (treeNode == null)
        {
            return;
        }
        DFS(treeNode.right);
        int temp = treeNode.val;
        treeNode.val += currSum;
        currSum += temp;
        DFS(treeNode.left);
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//     }
// }
