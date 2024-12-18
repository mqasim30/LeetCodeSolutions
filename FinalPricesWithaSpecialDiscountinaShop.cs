namespace LeetCode.FinalPricesWithaSpecialDiscountinaShop;

public class Solution
{
    public int[] FinalPrices(int[] a) =>
        a.Select((p, i) => p - a.Skip(i + 1).FirstOrDefault(q => q <= p)).ToArray();
}