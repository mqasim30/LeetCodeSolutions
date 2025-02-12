namespace LeetCode.MaxSumofaPairWithEqualSumofDigits;

public class Solution
{
    public int MaximumSum(int[] nums)
    {
        Dictionary<int, List<int>> digitSumMap = new Dictionary<int, List<int>>();

        foreach (int num in nums)
        {
            int sumOfDigits = GetSumOfDigits(num);
            if (!digitSumMap.ContainsKey(sumOfDigits))
            {
                digitSumMap[sumOfDigits] = new List<int>();
            }
            digitSumMap[sumOfDigits].Add(num);
        }

        int maxSum = -1;

        foreach (var pair in digitSumMap)
        {
            if (pair.Value.Count > 1)
            {
                pair.Value.Sort();
                int n = pair.Value.Count;
                maxSum = Math.Max(maxSum, pair.Value[n - 1] + pair.Value[n - 2]);
            }
        }

        return maxSum;
    }

    private int GetSumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}
