namespace LeetCode.CalculateMoneyinLeetcodeBank;

public class Solution
{
    public int TotalMoney(int n)
    {
        int currentMondayVal = 1;
        int total = 0;
        for (int i = 0; i < n; i++)
        {
            if (i % 7 == 0 && i != 0)
            {
                currentMondayVal++;
            }
            total += currentMondayVal + (i % 7);
        }
        return total;
    }
}