namespace LeetCode.FindtheMinimumandMaximumNumberofNodesBetweenCriticalPoints;


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
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        if (head == null || head.next == null || head.next.next == null)
        {
            return new int[] { -1, -1 };
        }

        List<int> criticalPoints = new List<int>();
        ListNode prev = head;
        ListNode curr = head.next;
        int position = 1;

        while (curr.next != null)
        {
            if ((curr.val > prev.val && curr.val > curr.next.val) ||
                (curr.val < prev.val && curr.val < curr.next.val))
            {
                criticalPoints.Add(position);
            }
            prev = curr;
            curr = curr.next;
            position++;
        }

        if (criticalPoints.Count < 2)
        {
            return new int[] { -1, -1 };
        }

        int minDistance = int.MaxValue;
        int maxDistance = criticalPoints[criticalPoints.Count - 1] - criticalPoints[0];

        for (int i = 1; i < criticalPoints.Count; i++)
        {
            minDistance = Math.Min(minDistance, criticalPoints[i] - criticalPoints[i - 1]);
        }

        return new int[] { minDistance, maxDistance };
    }
}