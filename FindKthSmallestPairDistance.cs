namespace LeetCode.FindKthSmallestPairDistance;

public class Solution
{
    public int SmallestDistancePair(int[] numbers, int k)
    {
        Array.Sort(numbers);
        int minDistance = 0;
        int maxDistance = numbers[^1] - numbers[0];
        while (minDistance < maxDistance)
        {
            int midDistance = minDistance + (maxDistance - minDistance) / 2;
            int pairsCount = CountPairsWithinDistance(numbers, midDistance);

            if (pairsCount < k)
            {
                minDistance = midDistance + 1;
            }
            else
            {
                maxDistance = midDistance;
            }
        }

        return minDistance;
    }

    private int CountPairsWithinDistance(int[] numbers, int targetDistance)
    {
        int count = 0;
        int left = 0;

        for (int right = 1; right < numbers.Length; right++)
        {
            while (numbers[right] - numbers[left] > targetDistance)
            {
                left++;
            }
            count += right - left;
        }

        return count;
    }
}
