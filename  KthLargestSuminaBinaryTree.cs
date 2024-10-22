namespace LeetCode.KthLargestSuminaBinaryTree;
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
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        // List to store the sum of each level
        List<long> levelSums = new List<long>();

        // If the tree is empty, return -1
        if (root == null)
        {
            return -1;
        }

        // Queue for level-order traversal
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            // Variable to store the sum of the current level
            long levelSum = 0;

            // Number of nodes at the current level
            int levelSize = q.Count;

            // Process each node at the current level
            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = q.Dequeue();

                // Add the node's value to the level sum
                levelSum += node.val;

                // Add child nodes to the queue for the next level
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }

            // Add the sum of the current level to the list
            levelSums.Add(levelSum);
        }

        // If there are fewer levels than k, return -1
        if (levelSums.Count < k)
        {
            return -1;
        }

        // Sort the level sums in descending order and return the kth largest
        levelSums.Sort((a, b) => b.CompareTo(a));
        return levelSums[k - 1];
    }
}