namespace LeetCode.RemoveDuplicatesfromSortedList
{
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
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode curr = head;

            if (head != null)
            {
                while (curr.next != null)
                {
                    if (curr.val == curr.next.val)
                    {
                        ListNode temp = curr.next;
                        curr.next = temp.next;
                    }
                    else
                    {
                        curr = curr.next;
                    }
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return head;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();

    //         ListNode list1 = new ListNode(1);
    //         list1.next = new ListNode(1);
    //         list1.next.next = new ListNode(2);
    //         list1.next.next.next = new ListNode(3);
    //         list1.next.next.next.next = new ListNode(3);

    //         ListNode newHead = solution.DeleteDuplicates(list1);
    //         while (newHead != null)
    //         {
    //             Console.WriteLine("Value: " + newHead.val);
    //             newHead = newHead.next;
    //         }
    //     }
    // }
}