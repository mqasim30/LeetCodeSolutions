namespace LeetCode.MinimumNumberofOperationstoSortaBinaryTreebyLevel;

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
    public int MinimumOperations(TreeNode root)
    {
        if (root == null) return 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int operations = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            var level = new List<int>();

            // Collect all nodes at the current level
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            // Calculate the minimum swaps needed for this level
            operations += CountMinSwaps(level);
        }

        return operations;
    }
    private int CountMinSwaps(List<int> level)
    {
        int n = level.Count;
        var arr = new int[n];
        var sortedArr = new int[n];

        // Copy values to arrays
        for (int i = 0; i < n; i++)
        {
            arr[i] = level[i];
            sortedArr[i] = level[i];
        }

        // Sort the array to get the target order
        Array.Sort(sortedArr);

        // Map each value to its index in the sorted array
        var indexMap = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            indexMap[sortedArr[i]] = i;
        }

        // Perform cycle detection to count swaps
        var visited = new bool[n];
        int swaps = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] || indexMap[arr[i]] == i) continue;

            int cycleSize = 0;
            int j = i;

            while (!visited[j])
            {
                visited[j] = true;
                j = indexMap[arr[j]];
                cycleSize++;
            }

            if (cycleSize > 1) swaps += cycleSize - 1;
        }

        return swaps;
    }
}