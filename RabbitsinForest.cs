namespace LeetCode.RabbitsinForest;

public class Solution
{
    public int NumRabbits(int[] answers)
    {
        var counter = new Dictionary<int, int>();
        int rabbits = answers.Length;

        foreach (var x in answers)
        {
            if (counter.ContainsKey(x) && counter[x] > 0)
            {
                counter[x]--;
            }
            else
            {
                counter[x] = x;
            }
        }

        foreach (var x in counter.Values)
        {
            rabbits += x;
        }

        return rabbits;
    }
}