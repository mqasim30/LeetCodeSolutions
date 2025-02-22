namespace LeetCode.RecoveraTreeFromPreorderTraversal;

public class TreeNode
{
    public int Val;
    public TreeNode left;
    public TreeNode right;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    {
        Val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public TreeNode RecoverFromPreorder(string traversal)
    {
        var stack = new Stack<TreeNode>();
        var i = 0;

        while (i < traversal.Length)
        {
            var level = 0;
            while (traversal[i] == '-')
            {
                level++;
                i++;
            }

            var val = 0;
            while (i < traversal.Length && traversal[i] != '-')
            {
                val = val * 10 + (traversal[i] - '0');
                i++;
            }

            var node = new TreeNode(val);

            while (stack.Count > level)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                if (stack.Peek().left == null)
                {
                    stack.Peek().left = node;
                }
                else
                {
                    stack.Peek().right = node;
                }
            }

            stack.Push(node);
        }

        while (stack.Count > 1)
        {
            stack.Pop();
        }

        return stack.Pop();

    }
}