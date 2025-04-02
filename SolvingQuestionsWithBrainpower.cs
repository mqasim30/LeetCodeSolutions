namespace LeetCode.SolvingQuestionsWithBrainpower;

public class Solution
{
    public long MostPoints(int[][] questions)
    {
        long result = questions[questions.Length - 1][0];
        long[] val = new long[questions.Length];
        long[] max = new long[questions.Length];
        max[questions.Length - 1] = questions[questions.Length - 1][0];
        val[questions.Length - 1] = questions[questions.Length - 1][0];

        for (int i = questions.Length - 2; i >= 0; i--)
        {
            if (questions[i][1] + i + 1 >= questions.Length)
                val[i] = questions[i][0];
            else
                val[i] = questions[i][0] + max[questions[i][1] + i + 1];
            max[i] = Math.Max(val[i], max[i + 1]);
            result = Math.Max(result, val[i]);
        }
        return result;
    }
}