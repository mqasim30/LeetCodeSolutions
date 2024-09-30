namespace LeetCode.DesignaStackWithIncrementOperation;

public class CustomStack
{
    private int[] stack;
    private int top = -1;

    public CustomStack(int maxSize)
    {
        stack = new int[maxSize];
    }

    public void Push(int x)
    {
        if (top < stack.Length - 1)
        {
            top++;
            stack[top] = x;
        }
    }

    public int Pop()
    {
        if (top != -1)
        {
            return stack[top--];
        }
        return -1;
    }

    public void Increment(int k, int val)
    {
        for (int i = 0; i < Math.Min(k, top + 1); i++)
        {
            stack[i] += val;
        }
    }
}