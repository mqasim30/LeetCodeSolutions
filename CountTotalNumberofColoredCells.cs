namespace LeetCode.CountTotalNumberofColoredCells;

public class Solution
{
    public long ColoredCells(int n)
    {
        return 1L + 2L * (n - 1) * n;
    }
}