namespace LeetCode.MinimumNumberofOperationstoMoveAllBallstoEachBox;

public class Solution
{
    public int[] MinOperations(string boxes)
    {
        int n = boxes.Length;
        int[] answer = new int[n];

        int count = 0;
        int operations = 0;
        for (int i = 0; i < n; i++)
        {
            answer[i] += operations;
            count += boxes[i] - '0';
            operations += count;
        }

        count = 0;
        operations = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            answer[i] += operations;
            count += boxes[i] - '0';
            operations += count;
        }

        return answer;
    }
}