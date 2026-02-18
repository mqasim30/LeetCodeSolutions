namespace LeetCode.BinaryNumberwithAlternatingBits;

public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        var prev = n & 1;
        n >>= 1;
        while (n > 0)
        {
            var current = n & 1;
            if (current == prev) return false;
            prev = current;
            n >>= 1;
        }
        return true;
    }
}