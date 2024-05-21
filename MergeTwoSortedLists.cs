namespace LeetCode.MergeTwoSortedLists
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
            Console.WriteLine("next: "+ next);
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = new ListNode(-1);
            ListNode mergedList = head;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    mergedList.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    mergedList.next = list2;
                    list2 = list2.next;
                }
                mergedList = mergedList.next;
            }
            
            if (list1 != null)
            {
                mergedList.next = list1;
            }
            else
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                mergedList.next = list2;
#pragma warning restore CS8601 // Possible null reference assignment.
            }

            return head.next;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         ListNode list1 = new ListNode(1);
    //         list1.next = new ListNode(2);
    //         list1.next.next = new ListNode(4);

    //         ListNode list2 = new ListNode(1);
    //         list2.next = new ListNode(3);
    //         list2.next.next = new ListNode(4);

    //         Solution solution = new Solution();

    //         ListNode mergedList = solution.MergeTwoLists(list1, list2);

    //         Console.WriteLine("Merged List:");
    //         while (mergedList != null)
    //         {
    //             Console.Write(mergedList.val + " ");
    //             mergedList = mergedList.next;
    //         }
    //         Console.WriteLine();
    //     }
    // }
}
