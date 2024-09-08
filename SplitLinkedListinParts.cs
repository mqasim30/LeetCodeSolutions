namespace LeetCode.SplitLinkedListinParts;
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

public class Solution
{
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        ListNode[] parts = new ListNode[k];
        ListNode temp = head;
        int index = 0;
        int count = 0;
        while (temp != null)
        {
            count++;
            temp = temp.next;
        }
        while (head != null)
        {
            int iteration = count / k;
            if (count % k != 0)
                iteration = count / k + 1;
            ListNode sublistHead = new ListNode();
            ListNode sublistTemp = sublistHead;
            for (int i = 0; i < iteration; i++)
            {
                sublistTemp.next = new ListNode(head.val);
                sublistTemp = sublistTemp.next;
                head = head.next;
            }
            parts[index] = sublistHead.next;
            count -= iteration;
            k -= 1;
            index++;
        }
        return parts;
    }
}