namespace LeetCode.CountNumberofTeams;

public class Solution
{
    public int NumTeams(int[] rating)
    {
        int n = rating.Length;
        if (n < 3) return 0;

        int min = int.MaxValue, max = int.MinValue;
        foreach (int num in rating)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        int[] leftTree = new int[max - min + 2];
        int[] rightTree = new int[max - min + 2];

        foreach (int num in rating)
        {
            Update(rightTree, num - min, 1);
        }

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            Update(rightTree, rating[i] - min, -1);

            int lessLeft = Query(leftTree, rating[i] - min - 1);
            int greaterLeft = i - lessLeft;

            int lessRight = Query(rightTree, rating[i] - min - 1);
            int greaterRight = (n - i - 1) - lessRight;

            count += lessLeft * greaterRight + greaterLeft * lessRight;

            Update(leftTree, rating[i] - min, 1);
        }

        return count;
    }

    private void Update(int[] tree, int index, int value)
    {
        index++;
        while (index < tree.Length)
        {
            tree[index] += value;
            index += index & (-index);
        }
    }

    private int Query(int[] tree, int index)
    {
        int sum = 0;
        index++;
        while (index > 0)
        {
            sum += tree[index];
            index -= index & (-index);
        }
        return sum;
    }
}
