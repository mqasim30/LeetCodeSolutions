namespace LeetCode.RemoveNodesFromLinkedList{

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
    public ListNode RemoveNodes(ListNode head) {
        Stack<int> nodes = new Stack<int>();
        ListNode curr = head;
        while(curr != null){
            while(nodes.Count != 0 && curr.val > nodes.Peek()){
                nodes.Pop();
            }
            nodes.Push(curr.val);
            curr = curr.next;
        }

        ListNode newHead = new ListNode(-1);
        curr = newHead;
        int[] array = new int[nodes.Count];
        Console.WriteLine(nodes.Count);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = nodes.Pop();
            Console.WriteLine("Array = "+ array[i]);
        }
        Console.WriteLine(array.Length);
        for (int i = 0; i < array.Length; i++)
        {
         Console.WriteLine(array[i]);   
        }
        Console.WriteLine("Ending");
        for (int i = array.Length-1 ; i >= 0 ; i--)
        {
            curr.next = new ListNode(array[i]);
            curr = curr.next; 
        }
        return newHead.next;
    }
}
    //  public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         ListNode listNode = new ListNode(5);
    //         listNode.next = new ListNode(2);
    //         listNode.next.next = new ListNode(13);
    //         listNode.next.next.next = new ListNode(3);
    //         listNode.next.next.next.next = new ListNode(8);
    //         ListNode test = solution.RemoveNodes(listNode);
    //         while(test != null)
    //         {
    //             Console.WriteLine(test.val);
    //             test = test.next;
    //         }

    //     }
    // }
}