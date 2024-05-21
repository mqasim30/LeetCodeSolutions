namespace LeetCode.DoubleaNumberRepresentedasaLinkedList
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
        public ListNode DoubleIt(ListNode head)
        {
            ListNode curr = head;
            List<int> nodeNumbers = new List<int>();
            while (curr.next != null)
            {
                nodeNumbers.Add(curr.val);
                curr = curr.next;
            }
            nodeNumbers.Add(curr.val);
            nodeNumbers.Reverse();
            int carry = 0;
            List<int> resultNumbers = new List<int>();
            foreach (var item in nodeNumbers)
            {
                int number = item * 2;
                if (carry != 0)
                {
                    number += carry;
                }
                string numberString = number.ToString();
                if (numberString.Length > 1)
                {
                    carry = (int)char.GetNumericValue(numberString[0]);
                    resultNumbers.Add((int)char.GetNumericValue(numberString[1]));
                }
                else
                {
                    resultNumbers.Add((int)char.GetNumericValue(numberString[0]));
                    carry = 0;
                }
            }
            if(carry!=0){
                resultNumbers.Add(carry);
            }
            resultNumbers.Reverse();
            ListNode temp = head;
            ListNode prev = head;
            foreach (var item in resultNumbers)
            {
                if(temp != null){
                    temp.val = item;
                }
                else{
                    ListNode newNode = new ListNode(item);
                    prev.next = newNode;
                    break;
                }
                prev = temp;
                temp = temp.next;
            }
            return head;
        }
    }

//     public class Solution {
//     public ListNode DoubleIt(ListNode head) {
//         ListNode first = new ListNode(0, head), prev = first;
//         while(head!=null) {
//             int d = head.val * 2;
//             if (d>=10) prev.val++;
//             head.val = d%10;
//             prev = head;
//             head = head.next;
//         }
//         return first.val > 0 ? first : first.next;
//     }
// }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         ListNode listNode = new ListNode(1);
    //         listNode.next = new ListNode(8);
    //         listNode.next.next = new ListNode(9);
    //         ListNode test = solution.DoubleIt(listNode);
    //         while (test != null)
    //         {
    //             Console.WriteLine(test.val);
    //             test = test.next;
    //         }

    //     }
    // }

}