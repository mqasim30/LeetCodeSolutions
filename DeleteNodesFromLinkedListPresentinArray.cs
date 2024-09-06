namespace LeetCode.DeleteNodesFromLinkedListPresentinArray;
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
 
public class Solution {
    public ListNode ModifiedList(int[] nums, ListNode head) {
        // Step 1: Sort the nums array
        Array.Sort(nums);
        
        // Step 2: Initialize pointers
        ListNode current = head;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        ListNode prev = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Step 3: Traverse the linke\d list
        while (current != null) {
            // Step 4: Perform binary search on the sorted nums array
            if (Array.BinarySearch(nums, current.val) >= 0) {
                // If the current node needs to be removed
                if (prev != null) {
                    // Skip the current node
                    prev.next = current.next;
                } else {
                    // Update head if we are at the beginning
                    head = current.next;
                }
            } else {
                // Move prev to the current node if it is not removed
                prev = current;
            }
            // Move to the next node
            current = current.next;
        }

        // Step 5: Return the modified head
        return head;
    }
}