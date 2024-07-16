namespace LeetCode.CreateBinaryTreeFromDescriptions;

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
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        HashSet<int> childrenSet = new HashSet<int>();
        Dictionary<int, int[]> childrenHashmap = new Dictionary<int, int[]>();

        foreach (var desc in descriptions)
        {
            int parent = desc[0];
            int child = desc[1];
            bool isLeft = desc[2] == 1;

            if (!childrenHashmap.ContainsKey(parent))
            {
                childrenHashmap[parent] = new int[] { -1, -1 };
            }
            childrenSet.Add(child);

            if (isLeft)
            {
                childrenHashmap[parent][0] = child;
            }
            else
            {
                childrenHashmap[parent][1] = child;
            }
        }

        int headNodeVal = 0;
        foreach (var parent in childrenHashmap.Keys)
        {
            if (!childrenSet.Contains(parent))
            {
                headNodeVal = parent;
                break;
            }
        }

        return ConstructTree(headNodeVal, childrenHashmap);
    }

    private TreeNode ConstructTree(int curNodeVal, Dictionary<int, int[]> childrenHashmap)
    {
        TreeNode newNode = new TreeNode(curNodeVal);
        if (childrenHashmap.ContainsKey(curNodeVal))
        {
            int[] children = childrenHashmap[curNodeVal];
            if (children[0] != -1)
            {
                newNode.left = ConstructTree(children[0], childrenHashmap);
            }
            if (children[1] != -1)
            {
                newNode.right = ConstructTree(children[1], childrenHashmap);
            }
        }
        return newNode;
    }
}


// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[][] descriptions = [[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]];
//         Console.WriteLine(solution.CreateBinaryTree(descriptions));
//     }
// }

