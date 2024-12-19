namespace LeetCode.MaxChunksToMakeSorted;

public class Solution
{
    public int MaxChunksToSorted(int[] arr)
    {
        int n = arr.Length;
        int chunks = 0;

        int prefixSumOriginal = 0;
        int prefixSumSorted = 0;

        int[] sortedArr = (int[])arr.Clone();
        Array.Sort(sortedArr);

        for (int i = 0; i < n; i++)
        {
            prefixSumOriginal += arr[i];
            prefixSumSorted += sortedArr[i];

            if (prefixSumOriginal == prefixSumSorted)
            {
                chunks++;
            }
        }

        return chunks;
    }
}