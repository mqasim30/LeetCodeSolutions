namespace LeetCode.SuccessfulPairsofSpellsandPotions;

public class Solution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        var result = new int[spells.Length];
        Array.Sort(potions);

        for (int i = 0; i < spells.Length; i++)
        {
            result[i] = potions.Length - BinarySearch(potions, spells[i], success);
        }

        return result;
    }

    private int BinarySearch(int[] potions, long spells, long success)
    {
        var left = 0;
        var right = potions.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (potions[mid] * spells >= success)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}