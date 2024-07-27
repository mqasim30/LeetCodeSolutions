namespace LeetCode.MinimumCosttoConvertStringI;

public class Solution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        int[][] dis = new int[26][];
        for (int i = 0; i < 26; i++)
        {
            dis[i] = new int[26];
            for (int j = 0; j < 26; j++)
            {
                dis[i][j] = int.MaxValue;
            }
            dis[i][i] = 0;
        }

        for (int i = 0; i < cost.Length; i++)
        {
            dis[original[i] - 'a'][changed[i] - 'a'] = Math.Min(dis[original[i] - 'a'][changed[i] - 'a'], cost[i]);
        }

        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                if (dis[i][k] < int.MaxValue)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (dis[k][j] < int.MaxValue)
                        {
                            dis[i][j] = Math.Min(dis[i][j], dis[i][k] + dis[k][j]);
                        }
                    }
                }
            }
        }

        long ans = 0L;
        for (int i = 0; i < source.Length; i++)
        {
            int c1 = source[i] - 'a';
            int c2 = target[i] - 'a';
            if (dis[c1][c2] == int.MaxValue)
            {
                return -1L;
            }
            else
            {
                ans += (long)dis[c1][c2];
            }
        }
        return ans;
    }
}
