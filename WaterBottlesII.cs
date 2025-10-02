namespace LeetCode.WaterBottlesII;

public class Solution
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        int res = numBottles, full = 0, empty = numBottles;
        while (empty >= numExchange || full > 0)
        {
            while (empty >= numExchange)
            {
                empty -= numExchange;
                full++;
                numExchange++;
            }
            res += full;
            empty += full;
            full = 0;
        }
        return res;
    }
}