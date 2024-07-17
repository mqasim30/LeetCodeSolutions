namespace LeetCode.DeleteNodesAndReturnForest;

using System;
using System.Collections.Generic;

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
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        Dictionary<int, TreeNode> res = new Dictionary<int, TreeNode>();
        HashSet<int> toDeleteSet = new HashSet<int>(to_delete);

        res[root.val] = root;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Recursion(null, root, false, res, toDeleteSet);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        return new List<TreeNode>(res.Values);
    }

    private void Recursion(TreeNode parent, TreeNode curNode, bool isLeft, Dictionary<int, TreeNode> res, HashSet<int> toDeleteSet)
    {
        if (curNode == null) return;

        Recursion(curNode, curNode.left, true, res, toDeleteSet);
        Recursion(curNode, curNode.right, false, res, toDeleteSet);

        if (toDeleteSet.Contains(curNode.val))
        {
            res.Remove(curNode.val);

            if (parent != null)
            {
                if (isLeft)
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    parent.left = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                }
                else
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    parent.right = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                }
            }

            if (curNode.left != null)
            {
                res[curNode.left.val] = curNode.left;
            }
            if (curNode.right != null)
            {
                res[curNode.right.val] = curNode.right;
            }
        }
    }
}
