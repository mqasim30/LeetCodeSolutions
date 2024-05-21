namespace LeetCode.DistributeCoinsinBinaryTree
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
        private int totalMoves = 0;
        private int CalculateMoves(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            int leftExtra = CalculateMoves(node.left);
            int rightExtra = CalculateMoves(node.right);

            totalMoves += Math.Abs(leftExtra) + Math.Abs(rightExtra);

            return node.val + leftExtra + rightExtra - 1;
        }
        
        public int DistributeCoins(TreeNode root)
        {
            CalculateMoves(root);
            return totalMoves;
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