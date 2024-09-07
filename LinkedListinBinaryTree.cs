namespace LeetCode.LinkedListinBinaryTree;
public class ListNode {
    public int val;
    public ListNode next;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
 
public class Solution {
    public bool IsSubPath(ListNode head, TreeNode root) {
        if(head != null && root == null)    return false;
#pragma warning disable CS8604 // Possible null reference argument.
        if (IsMatch(head, root))     return true;
#pragma warning restore CS8604 // Possible null reference argument.
        return IsSubPath(head, root.left) || IsSubPath(head, root.right);
    }

    private bool IsMatch(ListNode head, TreeNode root) {
        if(head != null && root == null)    return false;
        if(head == null)    return true;
        if(head.val != root.val)    return false;
        return IsMatch(head.next, root.left) || IsMatch(head.next, root.right);
    }
}