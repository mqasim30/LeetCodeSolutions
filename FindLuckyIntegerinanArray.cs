namespace LeetCode.FindLuckyIntegerinanArray;

public class Solution
{
    public int FindLucky(int[] arr)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        foreach (int num in arr)
        {
            if (frequency.ContainsKey(num))
            {
                frequency[num]++;
            }
            else
            {
                frequency[num] = 1;
            }
        }
        int luckyInteger = -1;
        foreach (var kvp in frequency)
        {
            if (kvp.Key == kvp.Value && kvp.Key > luckyInteger)
            {
                luckyInteger = kvp.Key;
            }
        }
        return luckyInteger;
    }
}