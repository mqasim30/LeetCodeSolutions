namespace LeetCode.NaryTreePostorderTraversal;
public class Node {
    public int val;
    public IList<Node> children;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Node() {}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Node(int _val) {
        val = _val;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}


public class Solution {
    List<int> res = new List<int>();
    
    void postOrder(Node root){
        if(root == null)
            return;
        foreach(Node child in root.children){
            postOrder(child);
            res.Add(child.val);
        }
    }
    
    public IList<int> Postorder(Node root) {
        if(root == null)
            return new List<int>();
        postOrder(root);
        res.Add(root.val);
        return res;
    }
}