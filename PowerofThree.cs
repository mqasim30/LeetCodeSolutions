namespace LeetCode.PowerofThree;
public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        int maxPowerOfThree = 1162261467;
        return n > 0 && (maxPowerOfThree % n == 0);
    }
}