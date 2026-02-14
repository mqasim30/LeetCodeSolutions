namespace LeetCode.ChampagneTower;

public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        double[][] tower = new double[query_row + 1][];
        for (int i = 0; i <= query_row; i++)
        {
            tower[i] = new double[i + 1];
        }

        tower[0][0] = poured;

        for (int row = 0; row < query_row; row++)
        {
            for (int glass = 0; glass < tower[row].Length; glass++)
            {
                double excess = (tower[row][glass] - 1) / 2.0;
                if (excess > 0)
                {
                    tower[row + 1][glass] += excess;
                    tower[row + 1][glass + 1] += excess;
                }
            }
        }

        return Math.Min(1.0, tower[query_row][query_glass]);
    }
}