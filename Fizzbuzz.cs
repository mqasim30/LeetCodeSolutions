namespace LeetCode.Fizzbuzz;

public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        List<string> answers = new List<string>(n);
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 != 0 && i % 5 != 0)
            {
                answers.Add(i.ToString());
                continue;
            }
            if (i % 3 == 0 && i % 5 == 0)
            {
                answers.Add("FizzBuzz");
                continue;
            }
            if (i % 3 == 0)
            {
                answers.Add("Fizz");
                continue;
            }
            if (i % 5 == 0)
            {
                answers.Add("Buzz");
                continue;
            }

        }

        return answers;
    }
}

