namespace LeetCode.ConstructtheLexicographicallyLargestValidSequence;

public class Solution
{
    public int[] ConstructDistancedSequence(int n)
    {
        int[] result = new int[2 * n - 1];
        bool[] visited = new bool[n + 1];
        Construct(result, visited, 0, n);
        return result;
    }

    private bool Construct(int[] result, bool[] visited, int index, int n)
    {
        if (index == result.Length) return true;
        if (result[index] != 0) return Construct(result, visited, index + 1, n);

        for (int i = n; i > 0; i--)
        {
            if (visited[i]) continue;
            visited[i] = true;
            result[index] = i;
            if (i == 1)
            {
                if (Construct(result, visited, index + 1, n)) return true;
            }
            else if (index + i < result.Length && result[index + i] == 0)
            {
                result[index + i] = i;
                if (Construct(result, visited, index + 1, n)) return true;
                result[index + i] = 0;
            }
            visited[i] = false;
            result[index] = 0;
        }

        return false;
    }
}