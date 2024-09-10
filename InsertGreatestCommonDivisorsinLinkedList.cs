namespace LeetCode.InsertGreatestCommonDivisorsinLinkedList;
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
    // Helper function to calculate GCD
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        if (head == null || head.next == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return head;
#pragma warning restore CS8603 // Possible null reference return.
        }

        // Create a new dummy node to act as the head of the new list
        ListNode dummy = new ListNode(0);
        ListNode newListTail = dummy;

        // Pointer to traverse the original list
        ListNode current = head;

        while (current != null && current.next != null)
        {
            // Append the current node from the original list to the new list
            newListTail.next = new ListNode(current.val);
            newListTail = newListTail.next;

            // Calculate GCD of the current node and the next node
            int gcdValue = GCD(current.val, current.next.val);

            // Create and insert the GCD node in the new list
            newListTail.next = new ListNode(gcdValue);
            newListTail = newListTail.next;

            // Move to the next node in the original list
            current = current.next;
        }

        // Append the last node (as there's no GCD node after the last one)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        newListTail.next = new ListNode(current.val);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        // Return the new list starting from the node after the dummy node
        return dummy.next;
    }
}