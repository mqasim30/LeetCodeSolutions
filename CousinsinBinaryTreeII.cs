namespace LeetCode.CousinsinBinaryTreeII;

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


using System;
using System.Collections.Generic;

public class Solution
{
    // List to store the sum of node values at each depth
    private List<int> depthSum;

    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        depthSum = new List<int>();
        // First DFS to calculate depth sums
        Dfs1(root, 0);
        // Second DFS to replace values, starting with 0 for the root
        Dfs2(root, 0, 0);
        // Return the modified root
        return root;
    }

    // First DFS to calculate the sum of node values at each depth
    private void Dfs1(TreeNode root, int d)
    {
        if (root == null) return;  // Base case: if the node is null, return

        // If the current depth is greater than or equal to the list size,
        // add a new element with the current node's value
        if (d >= depthSum.Count)
        {
            depthSum.Add(root.val);
        }
        // Otherwise, add the current node's value to the existing sum at this depth
        else
        {
            depthSum[d] += root.val;
        }

        // Recursively call Dfs1 for left and right children, incrementing the depth
        Dfs1(root.left, d + 1);
        Dfs1(root.right, d + 1);
    }

    // Second DFS to replace node values
    private void Dfs2(TreeNode root, int val, int d)
    {
        if (root == null) return;  // Base case: if the node is null, return

        // Replace the current node's value with the passed 'val'
        root.val = val;

        // Calculate the sum of cousin nodes' values
        // If there's a next depth, get its sum, otherwise use 0
        int c = d + 1 < depthSum.Count ? depthSum[d + 1] : 0;
        // Subtract the values of the current node's children (if they exist)
        c -= (root.left != null ? root.left.val : 0);
        c -= (root.right != null ? root.right.val : 0);

        // Recursively call Dfs2 for left and right children
        // Pass the calculated cousin sum 'c' and increment the depth
        if (root.left != null) Dfs2(root.left, c, d + 1);
        if (root.right != null) Dfs2(root.right, c, d + 1);
    }
}