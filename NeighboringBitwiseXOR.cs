namespace LeetCode.NeighboringBitwiseXOR;

public class Solution
{
    public bool DoesValidArrayExist(int[] derived)
    {
        int xor = 0;
        foreach (int value in derived)
        {
            xor ^= value;
        }
        return xor == 0;
    }
}