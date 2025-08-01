namespace LeetCode.ConvertBinaryNumberinaLinkedListtoInteger;

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
    public int GetDecimalValue(ListNode head)
    {
        uint result = 0;
        while (head != null)
        {
            result <<= 1;
            result += (uint)head.val;
            head = head.next;
        }

        return (int)result;
    }
}