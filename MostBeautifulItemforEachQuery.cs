namespace LeetCode.MostBeautifulItemforEachQuery;

public class Solution
{
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        var priceToBeauty = new Dictionary<int, int>();
        foreach (var item in items)
        {
            int price = item[0], beauty = item[1];
            if (!priceToBeauty.ContainsKey(price))
            {
                priceToBeauty[price] = beauty;
            }
            else
            {
                priceToBeauty[price] = Math.Max(priceToBeauty[price], beauty);
            }
        }

        var sortedPrices = new List<int>(priceToBeauty.Keys);
        sortedPrices.Sort();

        for (int i = 1; i < sortedPrices.Count; i++)
        {
            priceToBeauty[sortedPrices[i]] = Math.Max(priceToBeauty[sortedPrices[i]], priceToBeauty[sortedPrices[i - 1]]);
        }

        int[] results = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int queryPrice = queries[i];
            int maxBeauty = GetMaxBeauty(sortedPrices, priceToBeauty, queryPrice);
            results[i] = maxBeauty;
        }

        return results;
    }
    private int GetMaxBeauty(List<int> sortedPrices, Dictionary<int, int> priceToBeauty, int queryPrice)
    {
        int left = 0, right = sortedPrices.Count - 1;
        int result = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (sortedPrices[mid] <= queryPrice)
            {
                result = priceToBeauty[sortedPrices[mid]];
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}