namespace LeetCode.ConstructBinaryTreefromPreorderandPostorderTraversal;

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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        if (preorder == null || postorder == null || preorder.Length != postorder.Length)
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.

        return BuildTree(preorder, 0, preorder.Length - 1, postorder, 0, postorder.Length - 1);
    }

    private TreeNode BuildTree(int[] preorder, int preStart, int preEnd,
                             int[] postorder, int postStart, int postEnd)
    {
        if (preStart > preEnd)
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.

        TreeNode root = new TreeNode(preorder[preStart]);

        if (preStart == preEnd)
            return root;

        int leftRootVal = preorder[preStart + 1];
        int leftRootIndex = -1;

        for (int i = postStart; i <= postEnd; i++)
        {
            if (postorder[i] == leftRootVal)
            {
                leftRootIndex = i;
                break;
            }
        }

        int leftSubtreeSize = leftRootIndex - postStart + 1;

        root.left = BuildTree(preorder, preStart + 1, preStart + leftSubtreeSize,
                            postorder, postStart, leftRootIndex);
        root.right = BuildTree(preorder, preStart + leftSubtreeSize + 1, preEnd,
                             postorder, leftRootIndex + 1, postEnd - 1);

        return root;
    }
}