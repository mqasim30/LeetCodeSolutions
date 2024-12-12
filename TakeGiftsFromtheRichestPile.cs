namespace LeetCode.TakeGiftsFromtheRichestPile;

public class Solution
{
    public long PickGifts(int[] gifts, int k)
    {
        List<int> piles = new List<int>(gifts);

        for (int i = 0; i < k; i++)
        {
            piles.Sort((a, b) => b.CompareTo(a));
            int maxGifts = piles[0];

            piles[0] = (int)Math.Floor(Math.Sqrt(maxGifts));
        }

        long totalGifts = 0;
        foreach (int pile in piles)
        {
            totalGifts += pile;
        }

        return totalGifts;
    }
}