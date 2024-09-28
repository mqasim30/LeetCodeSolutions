namespace LeetCode.DesignCircularDeque;

public class Node
{
    public int val;
    public Node prev;
    public Node next;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Node(int val)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        this.val = val;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        prev = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        next = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}

public class MyCircularDeque
{
    private Node head = new Node(-1);
    private Node tail = new Node(-1);
    private int size;
    private int currSize;

    public MyCircularDeque(int k)
    {
        head.next = tail;
        tail.prev = head;
        size = k;
        currSize = 0;
    }

    public bool InsertFront(int value)
    {
        if (currSize == size)
            return false;

        AddNode(head, value);
        currSize++;
        return true;
    }

    public bool InsertLast(int value)
    {
        if (currSize == size)
            return false;

        AddNode(tail.prev, value);
        currSize++;
        return true;
    }

    public bool DeleteFront()
    {
        if (currSize == 0)
            return false;

        DeleteNode(head.next);
        currSize--;
        return true;
    }

    public bool DeleteLast()
    {
        if (currSize == 0)
            return false;

        DeleteNode(tail.prev);
        currSize--;
        return true;
    }

    public int GetFront()
    {
        if (currSize == 0)
            return -1;

        return head.next.val;
    }

    public int GetRear()
    {
        if (currSize == 0)
            return -1;

        return tail.prev.val;
    }

    public bool IsEmpty()
    {
        return currSize == 0;
    }

    public bool IsFull()
    {
        return currSize == size;
    }

    private void AddNode(Node head, int value)
    {
        Node after = head.next;
        Node temp = new Node(value);
        head.next = temp;
        temp.prev = head;
        temp.next = after;
        after.prev = temp;
    }

    private void DeleteNode(Node head)
    {
        Node after = head.next;
        Node before = head.prev;
        before.next = after;
        after.prev = before;
    }
}


/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * boolean param_1 = obj.insertFront(value);
 * boolean param_2 = obj.insertLast(value);
 * boolean param_3 = obj.deleteFront();
 * boolean param_4 = obj.deleteLast();
 * int param_5 = obj.getFront();
 * int param_6 = obj.getRear();
 * boolean param_7 = obj.isEmpty();
 * boolean param_8 = obj.isFull();
 */