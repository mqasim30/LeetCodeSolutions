namespace LeetCode.NumberofWaystoDivideaLongCorridor;

public class Solution
{
    int MOD = 1_000_000_007;
    int[,] cache;
    public int NumberOfWays(string corridor)
    {
        int n = corridor.Length;
        cache = new int[n, 3];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cache[i, j] = -1;
            }
        }

        return Count(0, 0, corridor);
    }

    public int Count(int index, int seats, string corridor)
    {
        if (index == corridor.Length)
        {
            return seats == 2 ? 1 : 0;
        }

        if (cache[index, seats] != -1)
        {
            return cache[index, seats];
        }

        int result = 0;
        if (seats == 2)
        {
            if (corridor[index] == 'S')
            {
                result = Count(index + 1, 1, corridor);
            }
            else
            { // corridor[index] == 'P'
                result = (Count(index + 1, 0, corridor) + Count(index + 1, 2, corridor)) % MOD;
            }
        }
        else
        {
            if (corridor[index] == 'S')
            {
                result = Count(index + 1, seats + 1, corridor);
            }
            else
            { // corridor[index] == 'P'
                result = Count(index + 1, seats, corridor);
            }
        }

        cache[index, seats] = result;
        return result;
    }
}