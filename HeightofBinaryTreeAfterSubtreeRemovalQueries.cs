namespace LeetCode.HeightofBinaryTreeAfterSubtreeRemovalQueries;
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
    private int[] depth = new int[100001];
    private int[] levelArr = new int[100001];
    private int[] max1 = new int[100001];
    private int[] max2 = new int[100001];

    private int Height(TreeNode root, int level)
    {
        if (root == null) return 0;

        // Set the level and calculate depth for the current node
        levelArr[root.val] = level;
        depth[root.val] = 1 + Math.Max(Height(root.left, level + 1), Height(root.right, level + 1));

        // Update the highest and second-highest depths for the current level
        if (max1[level] < depth[root.val])
        {
            max2[level] = max1[level];
            max1[level] = depth[root.val];
        }
        else if (max2[level] < depth[root.val])
        {
            max2[level] = depth[root.val];
        }

        return depth[root.val];
    }

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        // Compute depths and max depths for each level
        Height(root, 0);

        // Process each query
        for (int i = 0; i < queries.Length; i++)
        {
            int q = queries[i];
            int level = levelArr[q];

            // Set result for each query based on max depths at the level
            queries[i] = (max1[level] == depth[q] ? max2[level] : max1[level]) + level - 1;
        }

        return queries;
    }
}