namespace LeetCode.ReorderedPowerof2;

public class Solution
{
    public bool ReorderedPowerOf2(int n) => Enumerable
        .Range(0, 30).Select(i => $"{1 << i}".OrderBy(_ => _)).Any($"{n}".OrderBy(_ => _).ToArray().SequenceEqual);
}