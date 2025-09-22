namespace LeetCode.CountElementsWithMaximumFrequency;

public class Solution
{
    public int MaxFrequencyElements(int[] nums)
    {
        int[] freq = new int[101];   // frequency array
        foreach (int num in nums)
        {
            freq[num]++;             // count occurrences
        }

        int max = 0;
        for (int i = 0; i < freq.Length; i++)
        {
            if (max < freq[i])
            {
                max = freq[i];       // find max frequency
            }
        }

        int count = 0;
        for (int i = 0; i < freq.Length; i++)
        {
            if (freq[i] == max) count += freq[i]; // sum all with max frequency
        }

        return count;
    }
}