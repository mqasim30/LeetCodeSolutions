namespace LeetCode.BinaryPrefixDivisibleBy5;

public class Solution
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        var results = new List<bool>(nums.Length);
        var current = 0;
        foreach (var digit in nums)
        {
            current = (current * 2 + digit) % 5;
            results.Add(current == 0);
        }

        return results;
    }
}