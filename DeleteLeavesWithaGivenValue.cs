namespace LeetCode.DeleteLeavesWithaGivenValue
{

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
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if(root == null){
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            if(root.left == null && root.right == null && root.val == target){
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            return root;
        }
    }
}