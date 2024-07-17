namespace LeetCode.StepByStepDirectionsFromaBinaryTreeNodetoAnother;

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
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TreeNode startNode = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Find the start node
        while (q.Count > 0)
        {
            TreeNode curNode = q.Dequeue();

            if (curNode.val == startValue)
            {
                startNode = curNode;
                break;
            }

            if (curNode.left != null)
            {
                q.Enqueue(curNode.left);
            }
            if (curNode.right != null)
            {
                q.Enqueue(curNode.right);
            }
        }

        // Create a map of child nodes to their parents
        Dictionary<int, TreeNode> nodesParents = new Dictionary<int, TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            TreeNode curNode = q.Dequeue();

            if (curNode.left != null)
            {
                nodesParents[curNode.left.val] = curNode;
                q.Enqueue(curNode.left);
            }
            if (curNode.right != null)
            {
                nodesParents[curNode.right.val] = curNode;
                q.Enqueue(curNode.right);
            }
        }

        // Track the path from the start node to the destination node
        HashSet<TreeNode> visited = new HashSet<TreeNode>();
#pragma warning disable CS8604 // Possible null reference argument.
        q.Enqueue(startNode);
#pragma warning restore CS8604 // Possible null reference argument.
        Dictionary<TreeNode, KeyValuePair<TreeNode, string>> trackedPath = new Dictionary<TreeNode, KeyValuePair<TreeNode, string>>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TreeNode destinationNode = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        while (q.Count > 0)
        {
            TreeNode curNode = q.Dequeue();
            visited.Add(curNode);

            if (curNode.val == destValue)
            {
                destinationNode = curNode;
                break;
            }

            if (nodesParents.ContainsKey(curNode.val) && !visited.Contains(nodesParents[curNode.val]))
            {
                TreeNode parent = nodesParents[curNode.val];
                q.Enqueue(parent);
                trackedPath[parent] = new KeyValuePair<TreeNode, string>(curNode, "U");
            }

            if (curNode.left != null && !visited.Contains(curNode.left))
            {
                q.Enqueue(curNode.left);
                trackedPath[curNode.left] = new KeyValuePair<TreeNode, string>(curNode, "L");
            }

            if (curNode.right != null && !visited.Contains(curNode.right))
            {
                q.Enqueue(curNode.right);
                trackedPath[curNode.right] = new KeyValuePair<TreeNode, string>(curNode, "R");
            }
        }

        // Construct the path from the tracked directions
        List<string> resultPath = new List<string>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TreeNode currentNode = destinationNode;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        while (currentNode != startNode)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var sourceAndDirection = trackedPath[currentNode];
#pragma warning restore CS8604 // Possible null reference argument.
            resultPath.Add(sourceAndDirection.Value);
            currentNode = sourceAndDirection.Key;
        }

        resultPath.Reverse();
        return string.Join("", resultPath);
    }
}