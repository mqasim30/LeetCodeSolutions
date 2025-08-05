namespace LeetCode.FruitsIntoBasketsII;

public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int count = 0;
        int n = baskets.Length;
        foreach (int fruit in fruits)
        {
            int unset = 1;
            for (int i = 0; i < n; i++)
            {
                if (fruit <= baskets[i])
                {
                    baskets[i] = 0;
                    unset = 0;
                    break;
                }
            }
            count += unset;
        }
        return count;
    }
}