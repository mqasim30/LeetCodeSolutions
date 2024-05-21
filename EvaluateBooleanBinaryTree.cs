namespace LeetCode.EvaluateBooleanBinaryTree
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
        public bool EvaluateTree(TreeNode root)
        {
            if (root.left != null && root.right != null)
            {
                return root.val == 1;
            }

            if (root.val == 2)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return EvaluateTree(root.left) || EvaluateTree(root.right);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            else if (root.val == 3)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return EvaluateTree(root.left) && EvaluateTree(root.right);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            return false;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //     }
    // }
}