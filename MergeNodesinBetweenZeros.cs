namespace LeetCode.MergeNodesinBetweenZeros;
public class ListNode
{
    public int val;
    public ListNode next;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public ListNode(int val = 0, ListNode next = null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeNodes(ListNode head)
    {
        ListNode modify = head.next;
        ListNode nextSum = modify;

        while (nextSum != null)
        {
            int sum = 0;
            while (nextSum.val != 0)
            {
                sum += nextSum.val;
                nextSum = nextSum.next;
            }

            modify.val = sum;
            nextSum = nextSum.next;
            modify.next = nextSum;
            modify = modify.next;
        }
        return head.next;
    }
}