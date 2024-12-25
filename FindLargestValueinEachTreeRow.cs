namespace LeetCode.FindLargestValueinEachTreeRow;

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
    public IList<int> LargestValues(TreeNode root)
    {
        var list = new List<int>();
        if (root == null)
            return list;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int len = queue.Count;
            var max = double.MinValue;
            for (int i = 0; i < len; i++)
            {
                var node = queue.Dequeue();
                max = Math.Max(max, node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            list.Add((int)max);
        }
        return list;
    }
}