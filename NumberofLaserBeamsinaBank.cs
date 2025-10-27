namespace LeetCode.SimpleBankSystem;

public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        List<int> device = new List<int>();

        foreach (string row in bank)
        {
            int count = row.Count(c => c == '1');
            if (count > 0)
            {
                device.Add(count);
            }
        }

        int total = 0;
        for (int i = 0; i < device.Count - 1; i++)
        {
            total += device[i] * device[i + 1];
        }

        return total;
    }
}